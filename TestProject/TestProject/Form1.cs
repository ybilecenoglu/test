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

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ProductDal productDal = new ProductDal();
        private ReturnException exception = new ReturnException();
        private void Form1_Load(object sender, EventArgs e)
        {

            gdwProduct.DataSource = productDal.GetAll();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            exception.returnExc(() =>
            {
                productDal.Add(new Models.Product
                {
                    ProductName = tbxProductName.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text
                });
                MessageBox.Show("Product Added...");
                gdwProduct.DataSource = productDal.GetAll();
            });
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            exception.returnExc(() => {
                productDal.Delete(new Models.Product
                {
                    ProductId = Convert.ToInt32(gdwProduct.SelectedCells[0].Value),
                });
                MessageBox.Show(String.Format("{0} Id's Product Removed...", gdwProduct.SelectedCells[0].Value.ToString()));
                gdwProduct.DataSource = productDal.GetAll();
            });
        }
    }
}
