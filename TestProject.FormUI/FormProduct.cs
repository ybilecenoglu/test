using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete.EF;
using TestProject.DataAccess.Concrete.NHibernate;
using TestProject.FormUI.Utilities;

namespace TestProject.Product
{
    public partial class FormProduct : Form
    {

        private IProductService _productService;
        private IFormItemClearService _formItemClearService;
        private IExceptionHandlerService _exceptionHandlerService;

        public FormProduct()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<ProductManager>();
            //_exceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
            _formItemClearService = FormItemClearManager.CreateAsFormItemClearManager(); //Singleton implement
            _exceptionHandlerService = new ExceptionHandlerManager();
        }
        private async void FormProduct_Load(object sender, EventArgs e)
        {
            await LoadProduct();
            await LoadCategories();
            await LoadSuppliers();
        }
        public async Task LoadProduct()
        {
            var result = await _productService.GetProducts();
            if (result.Success == true)
            {
                gdwProduct.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
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
            await _exceptionHandlerService.ReturnException(async () =>
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
                            await LoadProduct();
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
                        await LoadProduct();
                    }
                    else
                        MessageBox.Show(add_result.Message, "HATA !");
                }
            });
        }
        private async void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            await _exceptionHandlerService.ReturnException(async () =>
            {
                if (gdwProduct.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwProduct.CurrentRow.Cells[0].Value.ToString()))
                {
                    int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                    var product = await GetProductById(productID);
                    if (product != null)
                    {
                        tbxProductID.Text = product.ProductId.ToString();
                        tbxProductName.Text = product.ProductName;
                        cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(gdwProduct.CurrentRow.Cells[2].Value != null ? gdwProduct.CurrentRow.Cells[2].Value.ToString() : null);
                        cbxCategories.SelectedIndex = cbxCategories.FindString(gdwProduct.CurrentRow.Cells[3].Value != null ? gdwProduct.CurrentRow.Cells[3].Value.ToString() : null);
                        tbxQuantityPerUnit.Text = product.QuantityPerUnit;
                        tbxUnitPrice.Text = product.UnitPrice != null ? product.UnitPrice.ToString() : "";
                        tbxUnitInStock.Text = product.UnitsInStock != null ? product.UnitsInStock.ToString() : "";
                        tbxUnitsOnOrder.Text = product.UnitsOnOrder != null ? product.UnitsOnOrder.ToString() : "";
                        tbxReorderLevel.Text = product.ReorderLevel != null ? product.ReorderLevel.ToString() : "";

                        if (product.Discontinued == true)
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

        }
        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await _exceptionHandlerService.ReturnException(async () =>
            {
                if (gdwProduct.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwProduct.CurrentRow.Cells[0].Value.ToString()))
                {
                    DialogResult dialogResult = new DialogResult();
                    int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                    var product = await GetProductById(productID);

                    dialogResult = MessageBox.Show(String.Format("{0} silinsin mi ?", product.ProductName), "Ürün Silme", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (product != null)
                        {
                            var result = await _productService.DeleteProduct(product);
                            if (result.Success == true)
                            {
                                MessageBox.Show("Ürün silme işlemi başarılı bir şekilde gerçekleşti.");
                                await LoadProduct();
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
        }
        public async Task<TestProject.Entities.Concrete.Product> GetProductById(int id)
        {
            var product = await _productService.GetProduct(p => p.ProductId == id);
            return product.Data;
        }
        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            await _exceptionHandlerService.ReturnException(async () =>
            {
                var result = await _productService.GetProducts(x => x.ProductName.Contains(textBoxSearch.Text.ToLower()));
                if (result.Success == true)
                {
                    gdwProduct.DataSource = result.Data;
                }
                else
                    MessageBox.Show(result.Message);
            });

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
    }
}
