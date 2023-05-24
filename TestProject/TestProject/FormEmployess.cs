using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.DAL.Employee;
using TestProject.Models;

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
            utilities.exceptionHandler(async () =>
            {
                gdwEmployee.DataSource = await _employeeDAL.BindingList();

                cbxRegion.DataSource = await _employeeDAL.GetRegions();
                cbxRegion.SelectedIndex = -1;
                cbxRegion.DisplayMember = "RegionDescription";
                cbxRegion.ValueMember = "RegionID";

                cbxCity.DataSource = await _employeeDAL.GetTerritories();
                cbxCity.DisplayMember = "TerritoryDescription";
                cbxCity.ValueMember = "TerritoryID";
            });
        }

        private void gdwEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            utilities.exceptionHandler(async () =>
            {
                if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
                {
                    var employee = await _employeeDAL.GetAsync(Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value));
                    tbxLastName.Text = employee.LastName;
                    tbxFirstName.Text = employee.FirstName;
                    tbxTitle.Text = employee.Title;
                    tbxTitleOfCourtesy.Text = employee.TitleOfCourtesy;
                    dtpBirthDate.Value = employee.BirthDate != null ? employee.BirthDate.Value : DateTime.Now;
                    dtpHireDate.Value = employee.HireDate != null ? employee.HireDate.Value : DateTime.Now;
                    tbxAdress.Text = employee.Address;
                    cbxCity.SelectedIndex = cbxCity.FindString(employee.City);
                    cbxRegion.SelectedIndex = cbxRegion.FindString(employee.Region);
                    tbxPostalCode.Text = employee.PostalCode;
                    cbxCountry.SelectedIndex = cbxCountry.FindString(employee.Country != null ? employee.Country : "");
                    tbxPhone.Text = employee.HomePhone;
                    tbxExtension.Text = employee.Extension;
                    pictureBox.Image = utilities.byteToImage(employee.Photo);
                    rtbNote.Text = employee.Notes;
                }

            });
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
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
            //comboBox form ilk yüklemede object döndürdüğü bug type kontrolü ile çözüldü.
            if (cbxRegion.SelectedValue != null && cbxRegion.SelectedValue.GetType() == typeof(int))
            {
                int RegionID = Convert.ToInt32(cbxRegion.SelectedValue);
                cbxCity.DataSource = await _employeeDAL.GetTerritories(x => x.RegionId == RegionID);

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            utilities.exceptionHandler(async () =>
            {
                var employee = await _employeeDAL.GetAsync(Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value != null ? gdwEmployee.CurrentRow.Cells[0].Value : 0));
                if (employee != null)
                {
                    _employeeDAL.DeleteAsync(employee);
                    gdwEmployee.DataSource = await _employeeDAL.BindingList();
                    MessageBox.Show(String.Format("{0} Id's employee has been removed.", employee.EmployeeId));
                }
                else
                {
                    MessageBox.Show("Record is not found...");
                }
            });
        }
    }
}
