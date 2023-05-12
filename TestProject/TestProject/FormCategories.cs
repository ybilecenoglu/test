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
            gdwCategories.DataSource = await _categoryDal.GetAllAsync();
        }

        private async void gdwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var categories = await _categoryDal.GetAsync(gdwCategories.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwCategories.CurrentRow.Cells[0].Value) : 0);
            if (categories != null)
            {
                tbxCategoryName.Text = categories.CategoryName;
                rtbxDescripton.Text = categories.Description;
                pictureBox.Image = utilities.byteToImage(categories.Picture);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Picture files |*.jpg| Picture files |*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 filePath= openFileDialog1.FileName;
                 fileName= openFileDialog1.SafeFileName;
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
                    Picture = utilities.imageToByte(pictureBox.Image)
                });

                gdwCategories.DataSource= await _categoryDal.GetAllAsync();
            });
        }
    }
}
