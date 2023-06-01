using System;
using System.Windows.Forms;
using TestProject.FormUI;
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

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrders formOrders = new FormOrders();
            formOrders.ShowDialog(this);
        }
    }
}
