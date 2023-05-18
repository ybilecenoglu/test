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
using TestProject.Product;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduct product = new FormProduct();
            product.ShowDialog(this);
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategories categories = new FormCategories();
            categories.ShowDialog(this);
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployess formEmployess = new FormEmployess();
            formEmployess.ShowDialog(this);
        }
    }
}
