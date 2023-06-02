using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.Entities.Concrete;

namespace TestProject
{
    public partial class FormCategories : Form
    {

        private ICategoryService _categoryService;
        private IUtilitiesServices _utilitiesService;
        private string filePath;
        private string fileName;
        public FormCategories()
        {
            InitializeComponent();
            _categoryService = InstanceFactory.GetInstance<CategoryManager>();
            _utilitiesService = InstanceFactory.GetInstance<UtilitiesManager>();
        }

        private async void FormCategories_Load(object sender, EventArgs e)
        {
            await LoadCategories();
        }

        public async Task LoadCategories()
        {
            var result = await _categoryService.GetCategories();
            if (result.Success == true)
            {
                gdwCategories.DataSource = result.Data;
            }
            else
                MessageBox.Show(result.Message);
        }
        private async void gdwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdwCategories.CurrentRow.Cells[0].Value != null)
            {
                int categoryID = Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value);
                var result = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                if (result.Success == true)
                {
                    if (result.Data != null && result.Data !=null)
                    {
                        tbxCategoryID.Text = result.Data.CategoryId.ToString();
                        tbxCategoryName.Text = result.Data.CategoryName;
                        tbxDescripton.Text = result.Data.Description;
                        var imageResult = _utilitiesService.ByteToImage(result.Data.Picture);
                        if (imageResult.Success == true)
                        {
                            pictureBox.Image = imageResult.Data;
                        }
                        else
                            MessageBox.Show(imageResult.Message);

                    }
                }
                else
                    MessageBox.Show(result.Message);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pictures |*.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                fileName = openFileDialog1.SafeFileName;
            }
            if (filePath != null)
            {
                pictureBox.Image = Image.FromFile(filePath);
            }
        }

        private async void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (tbxCategoryID.Text != string.Empty)
            {
                int categoryID = Convert.ToInt32(tbxCategoryID.Text);
                var getCategoryResult = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                if (getCategoryResult.Success == true && getCategoryResult.Data != null)
                {
                    getCategoryResult.Data.CategoryName = tbxCategoryName.Text;
                    getCategoryResult.Data.Description = tbxDescripton.Text;
                    var imageToByteResult = _utilitiesService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
                    if (imageToByteResult.Success == true && imageToByteResult.Data != null)
                    {
                        getCategoryResult.Data.Picture = imageToByteResult.Data;
                    }
                    else { MessageBox.Show(imageToByteResult.Message); }

                    var updateCategoryResult = await _categoryService.UpdateCategory(getCategoryResult.Data);
                    if (updateCategoryResult.Success == true)
                    {
                        MessageBox.Show("Kategori güncelleme işlemi başarılı bir şekilde gerçekleşti.");
                        await LoadCategories();
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

                var imageToByteResult = _utilitiesService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
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
                    await LoadCategories();
                }
                else
                {
                    MessageBox.Show(addCategoryResult.Message);
                }
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (tbxCategoryID.Text != string.Empty)
            {
                int categoryID = Convert.ToInt32(tbxCategoryID.Text);
                var getCategoryResult = await _categoryService.GetCategory(c => c.CategoryId == categoryID);
                if (getCategoryResult.Success == true && getCategoryResult.Data !=null)
                {
                    var deleteCategoryResult = await _categoryService.DeleteCategory(getCategoryResult.Data);
                    if (deleteCategoryResult.Success == true)
                    {
                        MessageBox.Show("Kategori silme işlemi başarılı bir şekilde gerçekleşti.");
                        await LoadCategories();
                    }
                    else
                        MessageBox.Show(deleteCategoryResult.Message);
                }
                else
                    MessageBox.Show(getCategoryResult.Message);
            }
            else
                MessageBox.Show("Seçili kategori bulunamadı...");

        }

        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            var result = await _categoryService.GetCategories(c => c.CategoryName.Contains(tbxSearch.Text.ToLower()));
            if (result.Success == true && result.Data != null)
            {
                gdwCategories.DataSource = result.Data;
            }
            else
                MessageBox.Show(result.Message);
        }

        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _utilitiesService.TextBoxClear(tbxCategoryID, tbxCategoryName, tbxDescripton);
            gdwCategories.ClearSelection();
            pictureBox.Image= null;
        }
    }
}
