using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete.EF;

namespace TestProject.Product
{
    public partial class FormProduct : Form
    {

        private IProductService _productService;
        private ICategoryService _categoryService;
        private ISupplierService _supplierService;
        private IUtilitiesServices _utilitiesService;
        public FormProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EFProductDal());
            _categoryService = new CategoryManager(new EFCategoryDal());
            _supplierService = new SupplierManager(new EFSupplierDal());
            _utilitiesService = new UtilitiesManager();
            
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
            var result = await _categoryService.GetCategories();
            if (result.Success == true)
            {
                cbxCategories.DataSource = result.Data;
                cbxCategories.DisplayMember = "CategoryName";
                cbxCategories.ValueMember = "CategoryID";
            }
            else
                MessageBox.Show(result.Message);

        }
        public async Task LoadSuppliers()
        {
            cbxSuppliers.DataSource = await _supplierService.GetSuppliers();
            cbxSuppliers.DisplayMember = "CompanyName";
            cbxSuppliers.ValueMember = "SupplierID";
        }
        private void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            AddOrUpdate();
        }
        private async void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gdwProduct.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwProduct.CurrentRow.Cells[0].Value.ToString()))
            {
                int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                var product = await GetProductById(productID);
                if (product != null)
                {
                    tbxProductID.Text = product.ProductId.ToString();
                    tbxProductName.Text = product.ProductName;
                    cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(gdwProduct.CurrentRow.Cells[2].Value != null ? gdwProduct.CurrentRow.Cells[2].Value.ToString() : "");
                    cbxCategories.SelectedIndex = cbxCategories.FindString(gdwProduct.CurrentRow.Cells[3].Value != null ? gdwProduct.CurrentRow.Cells[3].Value.ToString() : "");
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
        }
        private async void btnRemove_Click(object sender, EventArgs e)
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
        }
        public async Task<TestProject.Entities.Concrete.Product> GetProductById(int id)
        {
            var product = await _productService.GetProduct(p => p.ProductId == id);
            return product.Data;
        }
        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var result = await _productService.GetProducts(x => x.ProductName.Contains(textBoxSearch.Text.ToLower()));
            if (result.Success == true)
            {
                gdwProduct.DataSource = result.Data;
            }
            else
                MessageBox.Show(result.Message);
        }
        public async void AddOrUpdate()
        {
            if (tbxProductID.Text != string.Empty)
            {
                int productID = Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value);
                var product = await _productService.GetProduct(p => p.ProductId == productID);

                if (product.Success == true)
                {
                    var result = await _productService.UpdateProduct(new Entities.Concrete.Product
                    {
                        ProductId = Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value.ToString()),
                        ProductName = tbxProductName.Text,
                        SupplierId = Convert.ToInt16(cbxSuppliers.SelectedValue),
                        CategoryId = Convert.ToInt16(cbxCategories.SelectedValue),
                        UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                        UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text),
                        UnitsOnOrder = Convert.ToInt16(tbxUnitsOnOrder.Text),
                        QuantityPerUnit = tbxQuantityPerUnit.Text,
                        Discontinued = rdbOnSale.Checked == true ? true : false,
                        ReorderLevel = Convert.ToInt16(tbxReorderLevel.Text)
                    });
                    if (result.Success == true)
                    {
                        MessageBox.Show("Ürün güncelleme işlemi başarılı bir şekilde gerçekleşti.");
                        await LoadProduct();
                    }
                }
            }
            else
            {
                var result = await _productService.AddProduct(new Entities.Concrete.Product
                {
                    ProductName = tbxProductName.Text,
                    SupplierId = Convert.ToInt16(cbxSuppliers.SelectedValue),
                    CategoryId = Convert.ToInt16(cbxCategories.SelectedValue),
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text),
                    UnitsOnOrder = Convert.ToInt16(tbxUnitsOnOrder.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text,
                    Discontinued = rdbOnSale.Checked == true ? true : false,
                    ReorderLevel = Convert.ToInt16(tbxReorderLevel.Text)
                });

                if (result.Success == true)
                {
                    MessageBox.Show("Ürün ekleme işlemi başarılı bir şekilde gerçekleşti.");
                    gdwProduct.DataSource = LoadProduct();
                }
                else
                    MessageBox.Show(result.Message);
            }
        }
        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _utilitiesService.TextBoxClear(
                tbxProductID,
                tbxProductName,
                tbxQuantityPerUnit,
                tbxReorderLevel,
                tbxUnitInStock,
                tbxUnitPrice,
                tbxUnitsOnOrder
                );
            gdwProduct.ClearSelection();
        }
    }
}
