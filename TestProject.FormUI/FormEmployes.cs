﻿using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.Entities.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject
{
    public partial class FormEmployes : Form
    {

        private IEmployeeService _employeeService;
        private ExceptionHandlerManager _exceptionHandlerService;
        private ConvertImageManager _convertImageService;
        private FormItemClearManager _formItemClearService;
        private PagedListManager _pagedListService;

        int pageNumber = 1;
        Result<List<Employee>> result_employeeList;
        IPagedList<Employee> pagedEmployeeList;
        public FormEmployes()
        {
            InitializeComponent();
            _employeeService = InstanceFactory.GetInstance<EmployeeManager>();
            _convertImageService = ConvertImageManager.CreateInstance();
            _formItemClearService = FormItemClearManager.CreateInstance(); //Singleton implement
            _exceptionHandlerService = ExceptionHandlerManager.CreateInstance();
            _pagedListService = PagedListManager.CreateInstance();
        }
        private async void FormEmployess_Load(object sender, EventArgs e)
        {
            await EmployeeListPaged();
        }
        private async void gdwEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
                {
                    int employeeID = Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value);
                    var employeeResult = await _employeeService.GetEmployee(e => e.EmployeeId == employeeID);
                    if (employeeResult.Success == true)
                    {
                        tbxEmployeeId.Text = employeeResult.Data.EmployeeId.ToString();
                        tbxLastName.Text = employeeResult.Data.LastName;
                        tbxFirstName.Text = employeeResult.Data.FirstName;
                        tbxTitle.Text = employeeResult.Data.Title;
                        tbxTitleOfCourtesy.Text = employeeResult.Data.TitleOfCourtesy;
                        dtpBirthDate.Value = employeeResult.Data.BirthDate != null ? employeeResult.Data.BirthDate.Value : DateTime.Now;
                        dtpHireDate.Value = employeeResult.Data.HireDate != null ? employeeResult.Data.HireDate.Value : DateTime.Now;
                        tbxAdress.Text = employeeResult.Data.Address;
                        tbxCity.Text = employeeResult.Data.City;
                        tbxRegion.Text = employeeResult.Data.Region;
                        tbxPostalCode.Text = employeeResult.Data.PostalCode;
                        tbxCountry.Text = employeeResult.Data.Country;
                        tbxPhone.Text = employeeResult.Data.HomePhone;
                        tbxExtension.Text = employeeResult.Data.Extension;
                        var imageResult = _convertImageService.ByteToImage(employeeResult.Data.Photo);
                        if (imageResult.Success == true)
                        {
                            pictureBox.Image = imageResult.Data;
                        }

                        rtbNote.Text = employeeResult.Data.Notes;
                    }
                    else
                        MessageBox.Show(employeeResult.Message);
                }
            });
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Picture files |*.jpg; *.jpeg; *.png";
            string filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
            if (filePath != string.Empty)
            {
                pictureBox.Image = Image.FromFile(filePath);
            }
        }
        
        private async void btnRemove_Click(object sender, EventArgs e)
        {
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (tbxEmployeeId.Text != string.Empty)
                {
                    int employeeId = Convert.ToInt32(tbxEmployeeId.Text);
                    var employeeResult = await _employeeService.GetEmployee(e => e.EmployeeId == employeeId);
                    if (employeeResult.Success == true)
                    {
                        var deleteResult = await _employeeService.DeleteEmployee(employeeResult.Data);
                        if (deleteResult.Success == true)
                        {
                            MessageBox.Show("Çalışan silme işlemi başarıyla gerçekleşti");
                            await EmployeeListPaged();
                        }
                        else
                            MessageBox.Show(deleteResult.Message);
                    }
                }
                else
                    MessageBox.Show("Kayıt bulunamadı...");
            });
            if (exception_result.Success == false)
                MessageBox.Show(exception_result.Message);
        }
        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            await EmployeeListPaged(e => e.LastName.Contains(tbxSearch.Text.ToLower()));

        }
        private async void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var result = await _exceptionHandlerService.ReturnException(async () =>
            {
                if (tbxEmployeeId.Text != string.Empty)
                {
                    int employeeID = Convert.ToInt32(tbxEmployeeId.Text);
                    var employeeResult = await _employeeService.GetEmployee(e => e.EmployeeId == employeeID);
                    if (employeeResult.Success == true)
                    {
                        employeeResult.Data.LastName = tbxLastName.Text;
                        employeeResult.Data.FirstName = tbxFirstName.Text;
                        employeeResult.Data.Address = tbxAdress.Text;
                        employeeResult.Data.Notes = rtbNote.Text;
                        employeeResult.Data.Title = tbxTitle.Text;
                        employeeResult.Data.TitleOfCourtesy = tbxTitleOfCourtesy.Text;
                        employeeResult.Data.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                        employeeResult.Data.HireDate = Convert.ToDateTime(dtpHireDate.Text);
                        employeeResult.Data.Region = tbxRegion.Text;
                        employeeResult.Data.City = tbxCity.Text;
                        employeeResult.Data.Country = tbxCountry.Text;
                        employeeResult.Data.PostalCode = tbxPostalCode.Text;
                        employeeResult.Data.HomePhone = tbxPhone.Text;
                        employeeResult.Data.Extension = tbxExtension.Text;
                        var imageResult = _convertImageService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
                        if (imageResult.Success == true)
                        {
                            employeeResult.Data.Photo = imageResult.Data;
                        }

                        var updateResult = await _employeeService.UpdateEmployee(employeeResult.Data);
                        if (updateResult.Success == true)
                        {
                            MessageBox.Show("Çalışan güncelleme başarıyla tamamlandı.");
                            await EmployeeListPaged();
                        }
                        else
                            MessageBox.Show(updateResult.Message);
                    }
                }
                else
                {
                    Employee employee = new Employee();

                    employee.LastName = tbxLastName.Text;
                    employee.FirstName = tbxFirstName.Text;
                    employee.Address = tbxAdress.Text;
                    employee.Notes = rtbNote.Text;
                    employee.Title = tbxTitle.Text;
                    employee.TitleOfCourtesy = tbxTitleOfCourtesy.Text;
                    employee.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                    employee.HireDate = Convert.ToDateTime(dtpHireDate.Text);
                    employee.Region = tbxRegion.Text;
                    employee.City = tbxCity.Text;
                    employee.Country = tbxCountry.Text;
                    employee.PostalCode = tbxPostalCode.Text;
                    employee.HomePhone = tbxPhone.Text;
                    employee.Extension = tbxExtension.Text;
                    var imageResult = _convertImageService.ImageToByte(pictureBox.Image, ImageFormat.Jpeg);
                    if (imageResult.Success == true)
                    {
                        employee.Photo = imageResult.Data;
                    }

                    var addResult = await _employeeService.AddEmployee(employee);
                    if (addResult.Success == true)
                    {
                        MessageBox.Show("Çalışan kaydı ekleme başarıyla gerçekleşti.");
                        await EmployeeListPaged();
                    }
                    else
                        MessageBox.Show(addResult.Message);
                }
            });
            if (result.Success == false)
                MessageBox.Show(result.Message);
        }
        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _formItemClearService.TextBoxClear(tbxEmployeeId, tbxAdress, tbxExtension, tbxFirstName, tbxLastName, tbxPhone, tbxPostalCode, tbxTitle, tbxTitleOfCourtesy);
            _formItemClearService.RichTextBoxClear(rtbNote);
            _formItemClearService.PictureBoxClear(pictureBox);
            gdwEmployee.ClearSelection();
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (pagedEmployeeList.HasPreviousPage)
            {
                pagedEmployeeList = await _pagedListService.GetPagedList(result_employeeList.Data, ++pageNumber);
                int undivided = result_employeeList.Data.Count % 10;
                btnNextPage.Enabled = pagedEmployeeList.HasNextPage;
                btnPrevious.Enabled = pagedEmployeeList.HasPreviousPage;
                gdwEmployee.DataSource = pagedEmployeeList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10 + 1);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pagedEmployeeList.HasPreviousPage)
            {
                pagedEmployeeList = await _pagedListService.GetPagedList(result_employeeList.Data, --pageNumber);
                int undivided = result_employeeList.Data.Count % 10;
                btnNextPage.Enabled = pagedEmployeeList.HasNextPage;
                btnPrevious.Enabled = pagedEmployeeList.HasPreviousPage;
                gdwEmployee.DataSource = pagedEmployeeList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10 + 1);
            }
        }

        public async Task EmployeeListPaged(Expression<Func<Entities.Concrete.Employee, bool>> filter = null)
        {
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                result_employeeList = filter != null ? await _employeeService.GetEmployees(filter) : await _employeeService.GetEmployees();
                pagedEmployeeList = await _pagedListService.GetPagedList(result_employeeList.Data, pageNumber);
                int undivided = result_employeeList.Data.Count % 10;
                gdwEmployee.DataSource = pagedEmployeeList.ToList();
                if (undivided == 0)
                {
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10);
                }
                else
                    lblPageNo.Text = string.Format("Page {0}/{1}", pageNumber, result_employeeList.Data.Count / 10 + 1);
            });
            if (exception_result.Success == false)
                MessageBox.Show(exception_result.Message);

        }
    }
}
