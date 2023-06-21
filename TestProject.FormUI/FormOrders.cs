using NHibernate.Criterion;
using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;

namespace TestProject.FormUI
{
    public partial class FormOrders : Form
    {
        private IOrderService _orderService;
        private IPagedListService _pagedListService;
        private IExceptionHandlerService ExceptionHandlerService;
        
        int pageNumber = 1;
        Result<List<Entities.Concrete.Order>> orderList;
        IPagedList<Entities.Concrete.Order> orderPageList;
        public FormOrders()
        {
            InitializeComponent();
            _orderService = InstanceFactory.GetInstance<OrderManager>();
            _pagedListService = InstanceFactory.GetInstance<PagedListManager>();
            ExceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
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
            await OrderListPaged();
            await LoadCustomers();
            await LoadEmployees();
        }

        private async void btnGetList_Click(object sender, EventArgs e)
        {
            var startDate = dtpStart.Value;
            var endDate = dtpEnd.Value;


            var exception_result = await ExceptionHandlerService.ReturnException(async () =>
            {
                await OrderListPaged(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
            });
            if (exception_result.Success == false)
                MessageBox.Show(exception_result.Message);
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (orderPageList.HasPreviousPage)
            {
                orderPageList = await _pagedListService.GetPagedList(orderList.Data, --pageNumber);
                int undivided = orderList.Data.Count % 10;
                btnNextPage.Enabled = orderPageList.HasNextPage;
                btnPrevious.Enabled = orderPageList.HasPreviousPage;
                dgwOrders.DataSource = orderPageList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10 + 1);
               
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (orderPageList.HasNextPage)
            {
                orderPageList = await _pagedListService.GetPagedList(orderList.Data, ++pageNumber);
                int undivided = orderList.Data.Count % 10;
                btnNextPage.Enabled = orderPageList.HasNextPage;
                btnPrevious.Enabled = orderPageList.HasPreviousPage;
                dgwOrders.DataSource = orderPageList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10 + 1);
            }
        }

        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            await OrderListPaged(o => o.CustomerId.Contains(tbxSearch.Text.ToLower()));
        }

        public async Task OrderListPaged(Expression<Func<Entities.Concrete.Order, bool>> filter = null)
        {
            orderList = filter != null ? await _orderService.GetAllOrder(filter) : await _orderService.GetAllOrder();
            int undivided = orderList.Data.Count % 10; // Son sayfa sayısı almak için kalan kontrolü
            orderPageList = await _pagedListService.GetPagedList(orderList.Data, pageNumber);
            dgwOrders.DataSource = orderPageList.ToList();
            if (undivided == 0)
            {
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10);
            }
            else
                lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, orderList.Data.Count / 10 + 1);

        }
    }
}
