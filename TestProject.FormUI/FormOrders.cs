using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.DataAccess.Concrete.EF;

namespace TestProject.FormUI
{
    public partial class FormOrders : Form
    {
        private IOrderService _orderService;
        public FormOrders()
        {
            InitializeComponent();
            _orderService = new OrderManager(new EFOrderDal());
        }

        public async Task LoadOrders()
        {
           
            var result = await _orderService.GetAllOrder();
            if (result.Success == true)
            {
                dgwOrders.DataSource = result.Data;
                
            }
            else
                MessageBox.Show(result.Message);
        }

        private async void FormOrders_Load(object sender, EventArgs e)
        {
            await LoadOrders();
        }
    }
}
