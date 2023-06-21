using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete;
using TestProject.Entities.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject
{
    public partial class FormCategories : Form
    {

        private ICategoryService _categoryService;
        private IConvertImageService _convertImageService;
        private IFormItemClearService _formItemClearService;
        private IExceptionHandlerService _exceptionHandlerService;
        private IPagedListService _pagedListService;

        private string filePath;
        int pageNumber = 1;
        Result<List<Category>> result_categoryList;
        IPagedList<Category> categoryPagedList;
        public FormCategories()
        {
            InitializeComponent();
            _categoryService = InstanceFactory.GetInstance<CategoryManager>();
            _convertImageService = InstanceFactory.GetInstance<ConvertImageManager>();
            _formItemClearService = FormItemClearManager.CreateAsFormItemClearManager();//Singleton implement
            _exceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
            _pagedListService = InstanceFactory.GetInstance<PagedListManager>();
        }

        private async void FormCategories_Load(object sender, EventArgs e)
        {
            await CategoryListPaged();
        }


        private async void gdwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (gdwCategories.CurrentRow.Cells[0].Value != null)
                {
                    int categoryID = Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value);
                    var result = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                    if (result.Success == true)
                    {
                        tbxCategoryID.Text = result.Data.CategoryId.ToString();
                        tbxCategoryName.Text = result.Data.CategoryName;
                        tbxDescripton.Text = result.Data.Description;
                        var imageResult = _convertImageService.ByteToImage(result.Data.Picture);
                        if (imageResult.Success == true)
                        {
                            pictureBox.Image = imageResult.Data;
                        }
                    }
                    else
                        MessageBox.Show(result.Message);
                }
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }

        private async void btnChoose_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                openFileDialog1.Filter = "Pictures |*.jpg; *.jpeg; *.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                }
                if (filePath != null)
                {
                    pictureBox.Image = Image.FromFile(filePath);
                }
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }

        private async void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {

                if (tbxCategoryID.Text != string.Empty)
                {
                    int categoryID = Convert.ToInt32(tbxCategoryID.Text);
                    var getCategoryResult = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                    if (getCategoryResult.Success == true && getCategoryResult.Data != null)
                    {
                        getCategoryResult.Data.CategoryName = tbxCategoryName.Text;
                        getCategoryResult.Data.Description = tbxDescripton.Text;
                        var imageToByteResult = _convertImageService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
                        if (imageToByteResult.Success == true && imageToByteResult.Data != null)
                        {
                            getCategoryResult.Data.Picture = imageToByteResult.Data;
                        }
                        else { MessageBox.Show(imageToByteResult.Message); }

                        var updateCategoryResult = await _categoryService.UpdateCategory(getCategoryResult.Data);
                        if (updateCategoryResult.Success == true)
                        {
                            MessageBox.Show("Kategori güncelleme işlemi başarılı bir şekilde gerçekleşti.");
                            await CategoryListPaged();
                        }
                        else
                        {
                            MessageBox.Show(updateCategoryResult.Message);
                        }
                    }
                    else
                        MessageBox.Show(getCategoryResult.Message);
                }
                else
                {

                    var imageToByteResult = _convertImageService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
                    Category category = new Category();
                    category.CategoryName = tbxCategoryName.Text;
                    category.Description = tbxDescripton.Text;

                    if (imageToByteResult.Success == true && imageToByteResult.Data != null)
                    {
                        category.Picture = imageToByteResult.Data;
                    }
                    else { MessageBox.Show(imageToByteResult.Message); }

                    var addCategoryResult = await _categoryService.AddCategory(category);
                    if (addCategoryResult.Success == true)
                    {
                        MessageBox.Show("Kategori ekleme işlemi başarılı bir şekilde gerçekleşti.");
                        await CategoryListPaged();
                    }
                    else
                    {
                        MessageBox.Show(addCategoryResult.Message);
                    }
                }
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (tbxCategoryID.Text != string.Empty)
                {
                    DialogResult dialogResult = new DialogResult();
                    int categoryID = Convert.ToInt32(tbxCategoryID.Text);
                    var category_result = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                    dialogResult = MessageBox.Show(string.Format("{0} silinsin mi ?", category_result.Data.CategoryName), "Ürün Silme", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (category_result.Success == true)
                        {
                            var deleteCategoryResult = await _categoryService.DeleteCategory(category_result.Data);
                            if (deleteCategoryResult.Success == true)
                            {
                                MessageBox.Show("Kategori silme işlemi başarılı bir şekilde gerçekleşti.");
                                await CategoryListPaged();
                            }
                            else
                                MessageBox.Show(deleteCategoryResult.Message);
                        }

                    }
                }
                else
                    MessageBox.Show("Seçili kategori bulunamadı...");
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }

        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            await CategoryListPaged(c => c.CategoryName.Contains(tbxSearch.Text.ToLower()));
        }

        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _formItemClearService.TextBoxClear(tbxCategoryID, tbxCategoryName, tbxDescripton);
            _formItemClearService.PictureBoxClear(pictureBox);
            gdwCategories.ClearSelection();

        }

        public async Task CategoryListPaged(Expression<Func<Entities.Concrete.Category, bool>> filter = null)
        {
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                result_categoryList = filter != null ? await _categoryService.GetCategories(filter) : await _categoryService.GetCategories();
                categoryPagedList = await _pagedListService.GetPagedList(result_categoryList.Data, pageNumber);
                int undivided = result_categoryList.Data.Count % 10;
                gdwCategories.DataSource = categoryPagedList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10);

                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10 + 1);
            });
            if (exception_result.Success == false)
            {
                MessageBox.Show(exception_result.Message);
            }

        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (categoryPagedList.HasNextPage)
            {
                categoryPagedList = await _pagedListService.GetPagedList(result_categoryList.Data, ++pageNumber);
                int undivided = result_categoryList.Data.Count % 10;
                btnNextPage.Enabled = categoryPagedList.HasNextPage;
                btnPrevious.Enabled = categoryPagedList.HasPreviousPage;
                gdwCategories.DataSource = categoryPagedList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10 + 1);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (categoryPagedList.HasPreviousPage)
            {
                categoryPagedList = await _pagedListService.GetPagedList(result_categoryList.Data, --pageNumber);
                int undivided = result_categoryList.Data.Count % 10;
                btnNextPage.Enabled = categoryPagedList.HasNextPage;
                btnPrevious.Enabled = categoryPagedList.HasPreviousPage;
                gdwCategories.DataSource = categoryPagedList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_categoryList.Data.Count / 10 + 1);
            }
        }
    }
}
