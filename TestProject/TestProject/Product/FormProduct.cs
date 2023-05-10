using Microsoft.EntityFrameworkCore.Query.Internal;
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
using TestProject.Data;
using TestProject.Database;
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

                gdwDataSource();

                //Combo box genericList configuration
                cbxCategories.DataSource = productDal.GetCategories();
                cbxCategories.DisplayMember = "CategoryName";
                cbxCategories.ValueMember = "CategoryID";

                //Combo box genericList configuration
                cbxSuppliers.DataSource = productDal.GetSuppliers();
                cbxSuppliers.DisplayMember = "CompanyName";
                cbxSuppliers.ValueMember = "SupplierID";
            });
            

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            exception.returnExc(() =>
            {
                var product = productDal.Get(Convert.ToInt16(lblProductId.Text != "" ? lblProductId.Text : null));
                if (product == null)
                {
                    productDal.Add(new Models.Product
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
                }
                else
                {
                    productDal.Update(new Models.Product
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
                }
                MessageBox.Show("Record Added/Updated complate...");
                gdwDataSource();
                clearFormItem();
            });
        }

        private void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            exception.returnExc(() =>
            {
                lblProductId.Text = gdwProduct.CurrentRow.Cells[0].Value != null ? gdwProduct.CurrentRow.Cells[0].Value.ToString() : "";
                var product = productDal.Get(Convert.ToInt16(lblProductId.Text));
                if (product != null)
                {
                    tbxProductName.Text = gdwProduct.CurrentRow.Cells[1].Value != null ? gdwProduct.CurrentRow.Cells[1].Value.ToString() : "";
                    cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(gdwProduct.CurrentRow.Cells[2].Value != null ? gdwProduct.CurrentRow.Cells[2].Value.ToString() : "");
                    cbxCategories.SelectedIndex = cbxCategories.FindString(gdwProduct.CurrentRow.Cells[3].Value != null ? gdwProduct.CurrentRow.Cells[3].Value.ToString() : "");
                    tbxQuantityPerUnit.Text = gdwProduct.CurrentRow.Cells[4].Value != null ? gdwProduct.CurrentRow.Cells[4].Value.ToString() : "";
                    tbxUnitPrice.Text = gdwProduct.CurrentRow.Cells[5].Value != null ? gdwProduct.CurrentRow.Cells[5].Value.ToString() : "";
                    tbxUnitInStock.Text = gdwProduct.CurrentRow.Cells[6].Value != null ? gdwProduct.CurrentRow.Cells[6].Value.ToString() : "";
                    tbxUnitsOnOrder.Text = gdwProduct.CurrentRow.Cells[7].Value != null ? gdwProduct.CurrentRow.Cells[7].Value.ToString() : "";
                    tbxReorderLevel.Text = gdwProduct.CurrentRow.Cells[8].Value != null ? gdwProduct.CurrentRow.Cells[8].Value.ToString() : "";

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
                    MessageBox.Show("Record is not found...");
            });
        }
        public void gdwDataSource() {

            gdwProduct.Rows.Clear();
            gdwProduct.Columns.Add("ProductID", "Id");
            gdwProduct.Columns.Add("ProductName", "Product Name");
            gdwProduct.Columns.Add("Supplier", "Supplier");
            gdwProduct.Columns.Add("Category", "Category");
            gdwProduct.Columns.Add("QuantityPerUnit", "QuantityPerUnit");
            gdwProduct.Columns.Add("UnitPrice", "UnitPrice");
            gdwProduct.Columns.Add("UnitsInStock", "UnitsInStock");
            gdwProduct.Columns.Add("UnitsOnOrder", "UnitsOnOrder");
            gdwProduct.Columns.Add("ReorderLevel", "ReorderLevel");
            gdwProduct.Columns.Add("Discontinued", "Discontinued");

            exception.returnExc(() =>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    var products = productDal.GetAll();

                    foreach (var product in products)
                    {
                        var category = context.Categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);
                        var supplier = context.Suppliers.FirstOrDefault(x => x.SupplierId == product.SupplierId);

                        gdwProduct.Rows.Add(product.ProductId, product.ProductName, supplier.CompanyName, category.CategoryName, product.QuantityPerUnit, product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder, product.ReorderLevel, product.Discontinued);
                    }
                }



            });
        }
        public void clearFormItem()
        {
            tbxProductName.Clear();
            tbxQuantityPerUnit.Clear();
            tbxUnitPrice.Clear();
            tbxQuantityPerUnit.Clear();
            tbxUnitInStock.Clear();
            tbxUnitsOnOrder.Clear();
            tbxReorderLevel.Clear();
            rdbNotForSeal.Checked = false;
            rdbOnSale.Checked = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            exception.returnExc(() =>
            {
                var product = productDal.Get(Convert.ToInt16(lblProductId.Text != "" ? lblProductId.Text : null));
                if (product != null)
                {
                    productDal.Delete(product);
                    MessageBox.Show("Record is deleted...");
                }
                else
                {
                    MessageBox.Show("Record is not found...");
                }
            });
        }
    }
}
