using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.DAL.Category;
using TestProject.Models;

namespace TestProject
{
    public partial class FormCategories : Form
    {
        private CategoryDal _categoryDal = new CategoryDal();
        private Utilities utilities = new Utilities();

        private string filePath;
        private string fileName;
        public FormCategories()
        {
            InitializeComponent();
        }

        private async void FormCategories_Load(object sender, EventArgs e)
        {
            gdwCategories.DataSource = await _categoryDal.BindingList();
        }

        private void gdwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            utilities.returnExc(async() => {

                if (gdwCategories.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwCategories.CurrentRow.Cells[0].Value.ToString()))
                {
                    var categories = await _categoryDal.GetAsync(gdwCategories.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value) : 0);
                    if (categories != null)
                    {
                        tbxCategoryName.Text = categories.CategoryName;
                        rtbxDescripton.Text = categories.Description;
                        pictureBox.Image = utilities.byteToImage(categories.Picture);
                    }
                }
            });
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Picture files |*.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 filePath= openFileDialog1.FileName;
                 fileName= openFileDialog1.SafeFileName;
            }
            if (filePath != null)
            {
                pictureBox.Image = Image.FromFile(filePath);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                _categoryDal.AddAsync(new Models.Category
                {
                    CategoryName = tbxCategoryName.Text,
                    Description = rtbxDescripton.Text,
                    Picture = utilities.imageToByte(pictureBox.Image, ImageFormat.Jpeg)
                });
                
                gdwCategories.DataSource = await _categoryDal.GetAllAsync();
                utilities.clearTextBox(tbxCategoryName);
                utilities.clearRichTextBox(rtbxDescripton);
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                if (gdwCategories.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwCategories.CurrentRow.Cells[0].Value.ToString()))
                {
                    DialogResult dialogResult = new DialogResult();
                    var category = await _categoryDal.GetAsync(gdwCategories.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value) : 0);
                    dialogResult = MessageBox.Show(String.Format("{0} choose product has been deleted ?", category.CategoryName), "Record Deleted", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (category != null)
                        {
                            _categoryDal.DeleteAsync(category);
                            gdwCategories.DataSource = await _categoryDal.GetAllAsync();
                            utilities.clearTextBox(tbxCategoryName);
                            utilities.clearRichTextBox(rtbxDescripton);
                            MessageBox.Show(String.Format("{0} category has been removed.", category.CategoryName));
                        }
                        else
                            MessageBox.Show("Record is not found...");
                    }
                }
                else
                {
                    MessageBox.Show("Category has been selected...");
                }
            });
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                if (gdwCategories.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwCategories.CurrentRow.Cells[0].Value.ToString()))
                {
                    var category = await _categoryDal.GetAsync(gdwCategories.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value) : 0);
                    if (category != null)
                    {
                        category.CategoryName = tbxCategoryName.Text;
                        category.Description = rtbxDescripton.Text;
                        category.Picture = utilities.imageToByte(pictureBox.Image, ImageFormat.Jpeg);
                        _categoryDal.UpdateAsync(category);
                        gdwCategories.DataSource = await _categoryDal.GetAllAsync();
                        utilities.clearTextBox(tbxCategoryName);
                        utilities.clearRichTextBox(rtbxDescripton);
                        MessageBox.Show(String.Format("{0} Id's category has been updated.", category.CategoryId));
                    }
                    else
                        MessageBox.Show("Record is not found...");
                }
                else
                    MessageBox.Show("Category has been selected");
            });

        }
        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            gdwCategories.DataSource = await _categoryDal.BindingList(x => x.CategoryName.Contains(tbxSearch.Text));
        }
    }
}
