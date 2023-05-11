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
        private Utilities utilities = new Utilities();

        private void FormProduct_Load(object sender, EventArgs e)
        {

            utilities.returnExc(async () =>
            {
                gdwProduct.DataSource = await productDal.GetAllAsync();
                cbxCategories.DataSource = await productDal.GetCategoriesAsync();
                
                cbxCategories.DisplayMember = "CategoryName";
                cbxCategories.ValueMember = "CategoryID";
                
                cbxSuppliers.DataSource = await productDal.GetSuppliersAsync();
                cbxSuppliers.DisplayMember = "CompanyName";
                cbxSuppliers.ValueMember = "SupplierID";
            });


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                    productDal.AddAsync(new Models.Product
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
                gdwProduct.DataSource = await productDal.GetAllAsync();
                utilities.clearTextBox(tbxProductName, tbxQuantityPerUnit, tbxReorderLevel, tbxUnitInStock, tbxUnitPrice,tbxUnitsOnOrder);
                utilities.unCheckedRadioBtn(rdbOnSale, rdbNotForSeal);
            });
        }

        private void gdwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            utilities.returnExc(async () =>
            {
                
                var product = await productDal.GetAsync(gdwProduct.CurrentRow.Cells[0].Value != null ? Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value):0);
                if (product != null)
                {
                    int supplierID = Convert.ToInt16(gdwProduct.CurrentRow.Cells[2].Value != null ? gdwProduct.CurrentRow.Cells[2].Value : 0);
                    int categoryID = Convert.ToInt16(gdwProduct.CurrentRow.Cells[3].Value != null ? gdwProduct.CurrentRow.Cells[3].Value : 0);
                    var supplier = await productDal.GetSuppliersAsync(x => x.SupplierId == supplierID);
                    var category = await productDal.GetCategoriesAsync(x => x.CategoryId== categoryID);

                    tbxProductName.Text = gdwProduct.CurrentRow.Cells[1].Value != null ? gdwProduct.CurrentRow.Cells[1].Value.ToString() : "";
                    cbxSuppliers.SelectedIndex = cbxSuppliers.FindString(supplier[0].CompanyName);
                    cbxCategories.SelectedIndex = cbxCategories.FindString(category[0].CategoryName);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async() =>
            {
                DialogResult dialogResult = new DialogResult();
                var product = await productDal.GetAsync(gdwProduct.CurrentRow.Cells[0].Value != null ? Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value):0);
                
                dialogResult = MessageBox.Show(String.Format("{0} choose product has been deleted ?",product.ProductName),"Record Deleted",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (product != null)
                    {
                        productDal.DeleteAsync(product);
                        MessageBox.Show(String.Format("{0} product is deleted",product.ProductName));
                        gdwProduct.DataSource = await productDal.GetAllAsync();
                        utilities.clearTextBox(tbxProductName, tbxQuantityPerUnit, tbxReorderLevel, tbxUnitInStock, tbxUnitPrice, tbxUnitsOnOrder);
                        utilities.unCheckedRadioBtn(rdbOnSale, rdbNotForSeal);
                    }
                    else
                    {
                        MessageBox.Show("Record is not found...");
                    }
                }
            });
        }

        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            gdwProduct.DataSource = await productDal.GetAllAsync(x => x.ProductName.Contains(textBoxSearch.Text.ToLower()));
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                var product = await productDal.GetAsync(gdwProduct.CurrentRow.Cells[0].Value != null ? Convert.ToInt16(gdwProduct.CurrentRow.Cells[0].Value) : 0);
                if (product == null)
                {
                    MessageBox.Show("Record is not found...");
                }
                else
                {
                    productDal.UpdateAsync(new Models.Product
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
                MessageBox.Show(String.Format("{0} Id's product updated...",product.ProductId));
                gdwProduct.DataSource = await productDal.GetAllAsync();
                utilities.clearTextBox(tbxProductName, tbxQuantityPerUnit, tbxReorderLevel, tbxUnitInStock, tbxUnitPrice, tbxUnitsOnOrder);
                utilities.unCheckedRadioBtn(rdbOnSale, rdbNotForSeal);
            });
        }
    }
}
