using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.DAL.Employee;
using TestProject.Models;
using static Azure.Core.HttpHeader;

namespace TestProject
{
    public partial class FormEmployess : Form
    {
        EmployeeDal _employeeDAL = new EmployeeDal();
        Utilities utilities = new Utilities();


        public FormEmployess()
        {
            InitializeComponent();
        }

        private void FormEmployess_Load(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                gdwEmployee.DataSource = await _employeeDAL.BindingList();

                cbxRegion.DataSource = await _employeeDAL.GetRegions();
                cbxRegion.DisplayMember = "RegionDescription";
                cbxRegion.ValueMember = "RegionID";

                cbxCity.DataSource = await _employeeDAL.GetTerritories();
                cbxCity.DisplayMember = "TerritoryDescription";
                cbxCity.ValueMember = "TerritoryID";
            });
        }

        private void gdwEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            utilities.returnExc(async () =>
            {
                if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
                {
                    var employee = await _employeeDAL.GetAsync(Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value));
                    tbxLastName.Text = gdwEmployee.CurrentRow.Cells[1].Value != null ? gdwEmployee.CurrentRow.Cells[1].Value.ToString() : "";
                    tbxFirstName.Text = gdwEmployee.CurrentRow.Cells[2].Value != null ? gdwEmployee.CurrentRow.Cells[2].Value.ToString() : "";
                    tbxTitle.Text = gdwEmployee.CurrentRow.Cells[3].Value != null ? gdwEmployee.CurrentRow.Cells[3].Value.ToString() : "";
                    tbxTitleOfCourtesy.Text = gdwEmployee.CurrentRow.Cells[4].Value != null ? gdwEmployee.CurrentRow.Cells[4].Value.ToString() : "";
                    dtpBirthDate.Value = gdwEmployee.CurrentRow.Cells[5].Value != null ? Convert.ToDateTime(gdwEmployee.CurrentRow.Cells[5].Value) : DateTime.Now;
                    dtpHireDate.Value = gdwEmployee.CurrentRow.Cells[6].Value != null ? Convert.ToDateTime(gdwEmployee.CurrentRow.Cells[6].Value) : DateTime.Now;
                    tbxAdress.Text = gdwEmployee.CurrentRow.Cells[7].Value != null ? gdwEmployee.CurrentRow.Cells[7].Value.ToString() : "";
                    cbxCity.SelectedIndex = cbxCity.FindString(gdwEmployee.CurrentRow.Cells[8].Value != null ? gdwEmployee.CurrentRow.Cells[8].Value.ToString() : "");
                    cbxRegion.SelectedIndex = cbxRegion.FindString(gdwEmployee.CurrentRow.Cells[9].Value != null ? gdwEmployee.CurrentRow.Cells[9].Value.ToString() : "");
                    tbxPostalCode.Text = gdwEmployee.CurrentRow.Cells[10].Value != null ? gdwEmployee.CurrentRow.Cells[10].Value.ToString() : "";
                    cbxCountry.SelectedIndex = cbxCountry.FindString(gdwEmployee.CurrentRow.Cells[11].Value != null ? gdwEmployee.CurrentRow.Cells[11].Value.ToString() : "");
                    tbxPhone.Text = gdwEmployee.CurrentRow.Cells[12].Value != null ? gdwEmployee.CurrentRow.Cells[12].Value.ToString() : "";
                    tbxExtension.Text = gdwEmployee.CurrentRow.Cells[13].Value != null ? gdwEmployee.CurrentRow.Cells[13].Value.ToString() : "";
                    //pictureBox.Image = utilities.byteToImage(employee.Photo);
                    rtbNote.Text = gdwEmployee.CurrentRow.Cells[15].Value != null ? gdwEmployee.CurrentRow.Cells[15].Value.ToString() : "";
                }

            });
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            utilities.returnExc(async () =>
            {
                if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
                {
                    var employee = await _employeeDAL.GetAsync(gdwEmployee.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value) : 0);
                    if (employee != null)
                    {

                        employee.LastName = tbxLastName.Text;
                        employee.FirstName = tbxFirstName.Text;
                        employee.Notes = rtbNote.Text;
                        employee.Title = tbxTitle.Text;
                        employee.TitleOfCourtesy = tbxTitleOfCourtesy.Text;
                        employee.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                        employee.HireDate = Convert.ToDateTime(dtpHireDate.Text);
                        employee.Region = cbxRegion.Text;
                        employee.City = cbxCity.Text;
                        employee.Country = cbxCountry.Text;
                        employee.PostalCode = tbxPostalCode.Text;
                        employee.HomePhone = tbxPhone.Text;
                        employee.Extension = tbxExtension.Text;
                        employee.Photo = utilities.imageToByte(pictureBox.Image, ImageFormat.Jpeg);

                        _employeeDAL.UpdateAsync(employee);
                        gdwEmployee.DataSource = await _employeeDAL.BindingList();
                        MessageBox.Show(String.Format("{0} Id's employee has been updated.", employee.EmployeeId));
                    }
                    else
                        MessageBox.Show("Record is not found...");
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

        private async void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxCity.DataSource = await _employeeDAL.GetTerritories(x => x.RegionId == );
        }
    }
}
