using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject.Product
{
    public partial class FormProduct : Form
    {

        private IProductService _productService;
        private IFormItemClearService _formItemClearService;
        private IExceptionHandlerService _exceptionHandlerService;
        private IPagedListService _pagedListService;

        int pageNumber = 1;
        Result<List<Entities.Concrete.Product>> result_productList;
        IPagedList<Entities.Concrete.Product> productPageList;
        public FormProduct()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<ProductManager>();
            //_exceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
            _formItemClearService = FormItemClearManager.CreateAsFormItemClearManager(); //Singleton implement
            _exceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
            _pagedListService = InstanceFactory.GetInstance<PagedListManager>();
        }
        private async void FormProduct_Load(object sender, EventArgs e)
        {
            await ProductListPaged();
            await LoadCategories();
            await LoadSuppliers();
        }
        public async Task LoadCategories()
        {
            var result = await _productService.GetCategories();
            if (result.Success == true)
            {
                cbxCategories.DataSource = result.Data;
                cbxCategories.DisplayMember = "CategoryName";
                cbxCategories.ValueMember = "CategoryID";
                cbxCategories.SelectedIndex = -1;
            }
            else
                MessageBox.Show(result.Message);

        }
        public async Task LoadSuppliers()
        {
            var result = await _productService.GetSuppliers();
            if (result.Success == true)
            {
                cbxSuppliers.DataSource = result.Data;
                cbxSuppliers.DisplayMember = "CompanyName";
                cbxSuppliers.ValueMember = "SupplierID";
                cbxSuppliers.SelectedIndex = -1;
            }
            else MessageBox.Show(result.Message);

        }
        private async void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (tbxProductID.Text != string.Empty)
                {
                    int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                    var product = await _productService.GetProduct(p => p.ProductId == productID);

                    bool kontrol = tbxUnitPrice.Text.Equals(typeof(int));
                    if (product.Success == true)
                    {
                        var update_result = await _productService.UpdateProduct(new Entities.Concrete.Product
                        {

                            ProductId = Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value.ToString()),
                            ProductName = tbxProductName.Text,
                            SupplierId = cbxSuppliers.SelectedValue != null ? Convert.ToInt16(cbxSuppliers.SelectedValue) : null,
                            CategoryId = cbxCategories.SelectedValue != null ? Convert.ToInt16(cbxCategories.SelectedValue) : null,
                            UnitPrice = tbxUnitPrice.Text != string.Empty ? Convert.ToDecimal(tbxUnitPrice.Text) : null,
                            UnitsInStock = tbxUnitInStock.Text != string.Empty ? Convert.ToInt16(tbxUnitInStock.Text) : null,
                            UnitsOnOrder = tbxUnitsOnOrder.Text != string.Empty ? Convert.ToInt16(tbxUnitsOnOrder.Text) : null,
                            QuantityPerUnit = tbxQuantityPerUnit.Text,
                            Discontinued = rdbOnSale.Checked == true ? true : false,
                            ReorderLevel = tbxReorderLevel.Text != string.Empty ? Convert.ToInt16(tbxReorderLevel.Text) : null
                        });
                        if (update_result.Success == true)
                        {
                            MessageBox.Show("Ürün güncelleme işlemi başarılı bir şekilde gerçekleşti.");
                            await ProductListPaged();
                        }
                        else
                            MessageBox.Show(update_result.Message);
                    }
                }
                else
                {
                    bool kontrol = tbxUnitPrice.Text.Equals(typeof(decimal));
                    var add_result = await _productService.AddProduct(new Entities.Concrete.Product
                    {
                        ProductName = tbxProductName.Text,
                        SupplierId = cbxSuppliers.SelectedValue != null ? Convert.ToInt16(cbxSuppliers.SelectedValue) : null,
                        CategoryId = cbxCategories.SelectedValue != null ? Convert.ToInt16(cbxCategories.SelectedValue) : null,
                        UnitPrice = tbxUnitPrice.Text != string.Empty ? Convert.ToDecimal(tbxUnitPrice.Text) : null,
                        UnitsInStock = tbxUnitInStock.Text != string.Empty ? Convert.ToInt16(tbxUnitInStock.Text) : null,
                        UnitsOnOrder = tbxUnitsOnOrder.Text != string.Empty ? Convert.ToInt16(tbxUnitsOnOrder.Text) : null,
                        QuantityPerUnit = tbxQuantityPerUnit.Text,
                        Discontinued = rdbOnSale.Checked == true ? true : false,
                        ReorderLevel = tbxReorderLevel.Text != string.Empty ? Convert.ToInt16(tbxReorderLevel.Text) : null
                    });

                    if (add_result.Success == true)
                    {
                        MessageBox.Show("Ürün ekleme işlemi başarılı bir şekilde gerçekleşti.");
                        await ProductListPaged();
                    }
                    else
                        MessageBox.Show(add_result.Message, "HATA !");
                }
            });

            if (result.Success == false)
                MessageBox.Show(result.Message);

        }
        private async void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (gdwProduct.CurrentRow.Cells[0].Value != null)
                {
                    int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                    int supplierID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[2].Value);
                    int categoryID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[3].Value);

                    var product_result = await _productService.GetProduct(p => p.ProductId == productID);
                    if (product_result.Success == true)
                    {
                        tbxProductID.Text = product_result.Data.ProductId.ToString();
                        tbxProductName.Text = product_result.Data.ProductName;
                        cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(await _productService.GetSupplierCompanyName(supplierID));
                        cbxCategories.SelectedIndex = cbxCategories.FindString(await _productService.GetCategoryName(categoryID));
                        tbxQuantityPerUnit.Text = product_result.Data.QuantityPerUnit;
                        tbxUnitPrice.Text = product_result.Data.UnitPrice != null ? product_result.Data.UnitPrice.ToString() : "";
                        tbxUnitInStock.Text = product_result.Data.UnitsInStock != null ? product_result.Data.UnitsInStock.ToString() : "";
                        tbxUnitsOnOrder.Text = product_result.Data.UnitsOnOrder != null ? product_result.Data.UnitsOnOrder.ToString() : "";
                        tbxReorderLevel.Text = product_result.Data.ReorderLevel != null ? product_result.Data.ReorderLevel.ToString() : "";

                        if (product_result.Data.Discontinued == true)
                        {
                            rdbOnSale.Checked = true;

                        }
                        else
                        {
                            rdbNotForSeal.Checked = true;
                        }
                    }
                    else
                        MessageBox.Show("Seçili kayıt bulunamadı.");
                }
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);

        }
        private async void btnRemove_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
             {
                 if (tbxProductID.Text != string.Empty)
                 {
                     DialogResult dialogResult = new DialogResult();
                     int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                     var product_result = await _productService.GetProduct(p => p.ProductId == productID);

                     dialogResult = MessageBox.Show(String.Format("{0} silinsin mi ?", product_result.Data.ProductName), "Ürün Silme", MessageBoxButtons.YesNo);
                     if (dialogResult == DialogResult.Yes)
                     {
                         if (product_result.Success == true)
                         {
                             var result = await _productService.DeleteProduct(product_result.Data);
                             if (result.Success == true)
                             {
                                 MessageBox.Show("Ürün silme işlemi başarılı bir şekilde gerçekleşti.");
                                 await ProductListPaged();
                             }
                             else
                                 MessageBox.Show(result.Message);
                         }
                         else
                         {
                             MessageBox.Show("Kayıt bulunamadı.");
                         }
                     }
                 }
             });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }
        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                await ProductListPaged(p => p.ProductName.Contains(textBoxSearch.Text.ToLower()));

            });
            if (exception_result.Success == false)
                MessageBox.Show(exception_result.Message);

        }
        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _formItemClearService.TextBoxClear(
            tbxProductID,
            tbxProductName,
            tbxQuantityPerUnit,
            tbxReorderLevel,
            tbxUnitInStock,
            tbxUnitPrice,
            tbxUnitsOnOrder
            );

            _formItemClearService.RadioButtonClear(rdbOnSale, rdbNotForSeal);
            _formItemClearService.ComboBoxClear(cbxCategories, cbxSuppliers);
            gdwProduct.ClearSelection();


        }
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (productPageList.HasPreviousPage)
            {
                productPageList = await _pagedListService.GetPagedList(result_productList.Data, --pageNumber);
                int undivided = result_productList.Data.Count % 10;
                btnNextPage.Enabled = productPageList.HasNextPage;
                btnPrevious.Enabled = productPageList.HasPreviousPage;
                gdwProduct.DataSource = productPageList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10 + 1);
            }
        }
        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (productPageList.HasNextPage)
            {
                productPageList = await _pagedListService.GetPagedList(result_productList.Data, ++pageNumber);
                int undivided = result_productList.Data.Count % 10;
                btnNextPage.Enabled = productPageList.HasNextPage;
                btnPrevious.Enabled = productPageList.HasPreviousPage;
                gdwProduct.DataSource = productPageList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10 + 1);
            }
        }
        public async Task ProductListPaged(Expression<Func<Entities.Concrete.Product, bool>> filter = null)
        {
            result_productList = filter != null ? await _productService.GetProducts(filter) : await _productService.GetProducts();
            productPageList = await _pagedListService.GetPagedList(result_productList.Data, pageNumber);
            int undivided = result_productList.Data.Count % 10;
            gdwProduct.DataSource = productPageList.ToList();
            if (undivided == 0)
            {
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10);
            }
            else
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_productList.Data.Count / 10 + 1);

        }
    }
}
