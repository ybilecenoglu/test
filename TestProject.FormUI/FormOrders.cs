using NHibernate.Criterion;
using PagedList;
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
using TestProject.Business.IoC.Ninject;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;

namespace TestProject.FormUI
{
    public partial class FormOrders : Form
    {
        private IOrderService _orderService;
        IPagedList<Entities.Concrete.Order> OrderList = null;
        int pageNumber = 1;
        public FormOrders()
        {
            InitializeComponent();
            _orderService = InstanceFactory.GetInstance<OrderManager>();
        }

        public async Task<IPagedList<Entities.Concrete.Order>> LoadOrders(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _orderService.GetAllOrder();
            if (result.Success == true)
            {
                return result.Data.OrderBy(x => x.OrderId).ToPagedList(pageNumber, pageSize);

            }
            else
                return null;
        }
        public async Task LoadCustomers()
        {
            var customer_result = await _orderService.GetCustomers();
            if (customer_result.Success == true)
            {
                cbxCustomer.DataSource = customer_result.Data;
                cbxCustomer.DisplayMember = "CompanyName";
                cbxCustomer.ValueMember = "CustomerID";
            }
            else
                MessageBox.Show(customer_result.Message);
        }
        public async Task LoadEmployees()
        {
            var employee_result = await _orderService.GetEmployees();
            if (employee_result.Success == true)
            {
                cbxEmployee.DataSource = employee_result.Data;
                cbxEmployee.DisplayMember = "FirstName";
                cbxEmployee.ValueMember = "EmployeeID";
            }
            else
                MessageBox.Show(employee_result.Message);

        }

        private async void FormOrders_Load(object sender, EventArgs e)
        {
            OrderList = await LoadOrders();
            btnNextPage.Enabled = OrderList.HasNextPage;
            btnPrevious.Enabled = OrderList.HasPreviousPage;
            dgwOrders.DataSource = OrderList.ToList();
            lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, OrderList.Count);
            await LoadCustomers();
            await LoadEmployees();
        }

        private async void btnGetList_Click(object sender, EventArgs e)
        {
            var startDate = dtpStart.Value;
            var endDate = dtpEnd.Value;

            var result = await _orderService.GetAllOrder(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
            if (result.Success == true)
            {
                dgwOrders.DataSource = result.Data;
            }
            else
                MessageBox.Show(result.Message);
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (OrderList.HasPreviousPage)
            {
                OrderList = await LoadOrders(--pageNumber);
                btnNextPage.Enabled = OrderList.HasNextPage;
                btnPrevious.Enabled = OrderList.HasPreviousPage;
                dgwOrders.DataSource = OrderList.ToList();
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, OrderList.Count);
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (OrderList.HasNextPage)
            {
                OrderList = await LoadOrders(++pageNumber);
                btnNextPage.Enabled = OrderList.HasNextPage;
                btnPrevious.Enabled = OrderList.HasPreviousPage;
                dgwOrders.DataSource = OrderList.ToList();
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, OrderList.Count);
            }
        }
    }
}
