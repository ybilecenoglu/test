using System;
using System.Windows.Forms;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;
namespace TestProject.Product
{
    public partial class FormProduct : Form
    {

        private IProductService ProductService;
        private ICategoryService CategoryService;
        private ISupplierService SupplierService;
        public FormProduct()
        {
            InitializeComponent();
            ProductService = new ProductManager(new EFProductDal());
            CategoryService = new CategoryManager(new EFCategoryDal());
            SupplierService = new SupplierManager(new EFSupplierDal());
        }
        private async void FormProduct_Load(object sender, EventArgs e)
        {
            gdwProduct.DataSource = await ProductService.GetProducts();

            cbxCategories.DataSource = await CategoryService.GetCategories();
            cbxCategories.DisplayMember = "CategoryName";
            cbxCategories.ValueMember = "CategoryID";

            cbxSuppliers.DataSource = await SupplierService.GetSuppliers();
            cbxSuppliers.DisplayMember = "CompanyName";
            cbxSuppliers.ValueMember = "SupplierID";

        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductService.AddProduct(new Entities.Concrete.Product
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

            MessageBox.Show("Product is added");
            gdwProduct.DataSource = await ProductService.GetProducts();
            
        }

        private void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gdwProduct.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwProduct.CurrentRow.Cells[0].Value.ToString()))
            {
                //var product = await ProductService.GetProduct(p => p.ProductId == Convert.ToInt32(gdwProduct.CurrentRow.Cells[0].Value));
                //if (product != null)
                //{

                //    tbxProductName.Text = gdwProduct.CurrentRow.Cells[1].Value != null ? gdwProduct.CurrentRow.Cells[1].Value.ToString() : "";
                //    cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(gdwProduct.CurrentRow.Cells[2].Value != null ? gdwProduct.CurrentRow.Cells[2].Value.ToString() : "");
                //    cbxCategories.SelectedIndex = cbxCategories.FindString(gdwProduct.CurrentRow.Cells[3].Value != null ? gdwProduct.CurrentRow.Cells[3].Value.ToString() : "");
                //    tbxQuantityPerUnit.Text = gdwProduct.CurrentRow.Cells[4].Value != null ? gdwProduct.CurrentRow.Cells[4].Value.ToString() : "";
                //    tbxUnitPrice.Text = gdwProduct.CurrentRow.Cells[5].Value != null ? gdwProduct.CurrentRow.Cells[5].Value.ToString() : "";
                //    tbxUnitInStock.Text = gdwProduct.CurrentRow.Cells[6].Value != null ? gdwProduct.CurrentRow.Cells[6].Value.ToString() : "";
                //    tbxUnitsOnOrder.Text = gdwProduct.CurrentRow.Cells[7].Value != null ? gdwProduct.CurrentRow.Cells[7].Value.ToString() : "";
                //    tbxReorderLevel.Text = gdwProduct.CurrentRow.Cells[8].Value != null ? gdwProduct.CurrentRow.Cells[8].Value.ToString() : "";

                //    if (product.Discontinued == true)
                //    {
                //        rdbOnSale.Checked = true;

                //    }
                //    else
                //    {
                //        rdbNotForSeal.Checked = true;
                //    }
                //}
                //else
                //    MessageBox.Show("Record is not found...");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //utilities.exceptionHandler(async() =>
            //{
            //    DialogResult dialogResult = new DialogResult();
            //    var product = await productDal.GetAsync(gdwProduct.CurrentRow.Cells[0].Value != null ? Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value):0);

            //    dialogResult = MessageBox.Show(String.Format("{0} choose product has been deleted ?",product.ProductName),"Record Deleted",MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        if (product != null)
            //        {
            //            productDal.DeleteAsync(product);
            //            MessageBox.Show(String.Format("{0} product is deleted",product.ProductName));
            //            gdwProduct.DataSource = await productDal.BindingList();
            //            utilities.clearTextBox(tbxProductName, tbxQuantityPerUnit, tbxReorderLevel, tbxUnitInStock, tbxUnitPrice, tbxUnitsOnOrder);
            //            utilities.unCheckedRadioBtn(rdbOnSale, rdbNotForSeal);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Record is not found...");
            //        }
            //    }
            //});
        }

        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            gdwProduct.DataSource = await ProductService.GetProducts(x => x.ProductName.Contains(textBoxSearch.Text.ToLower()));
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //utilities.exceptionHandler(async () =>
            //{
            //    var product = await productDal.GetAsync(gdwProduct.CurrentRow.Cells[0].Value != null ? Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value) : 0);
            //    if (product == null)
            //    {
            //        MessageBox.Show("Record is not found...");
            //    }
            //    else
            //    {
            //        productDal.UpdateAsync(new Models.Product
            //        {
            //            ProductId = Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value.ToString()),
            //            ProductName = tbxProductName.Text,
            //            SupplierId = Convert.ToInt16(cbxSuppliers.SelectedValue),
            //            CategoryId = Convert.ToInt16(cbxCategories.SelectedValue),
            //            UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
            //            UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text),
            //            UnitsOnOrder = Convert.ToInt16(tbxUnitsOnOrder.Text),
            //            QuantityPerUnit = tbxQuantityPerUnit.Text,
            //            Discontinued = rdbOnSale.Checked == true ? true : false,
            //            ReorderLevel = Convert.ToInt16(tbxReorderLevel.Text)
            //        });
            //    }
            //    MessageBox.Show(String.Format("{0} Id's product updated...",product.ProductId));
            //    gdwProduct.DataSource = await productDal.BindingList();
            //    utilities.clearTextBox(tbxProductName, tbxQuantityPerUnit, tbxReorderLevel, tbxUnitInStock, tbxUnitPrice, tbxUnitsOnOrder);
            //    utilities.unCheckedRadioBtn(rdbOnSale, rdbNotForSeal);
            //});
        }
    }
}
