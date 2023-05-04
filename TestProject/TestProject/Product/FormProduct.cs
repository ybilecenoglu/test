using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Database.Product;
using TestProject.Models;

namespace TestProject.Product
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }
        private ProductDal productDal = new ProductDal();
        private ReturnException exception = new ReturnException();

        private void FormProduct_Load(object sender, EventArgs e)
        {
            exception.returnExc(() =>
            {
                gdwProduct.DataSource = productDal.GetAll();
                cbxCategories.DataSource = productDal.GetCategories();
                cbxSuppliers.DataSource = productDal.GetSuppliers();
            });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            exception.returnExc(() =>
            {
                productDal.Add(new Models.Product
                {
                    ProductName = tbxProductName.Text,
                    SupplierId = Convert.ToInt16(cbxSuppliers.SelectedItem),
                    CategoryId = Convert.ToInt16(cbxCategories.SelectedItem),
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text,
                    Discontinued = rdbOnSale.Checked == true ? true : false,
                    ReorderLevel = Convert.ToInt16(tbxReorderLevel.Text)
                });
            });


        }
        
    }
}
