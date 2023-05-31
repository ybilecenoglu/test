using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject
{
    public partial class FormEmployess : Form
    {

        private IEmployeeService _employeeService;
        private IUtilitiesServices _utilitiesService;
        public FormEmployess()
        {
            InitializeComponent();
            _employeeService = new EmployeeManager(new EFEmployeeDal());
            _utilitiesService = new UtilitiesManager();
        }

        private async void FormEmployess_Load(object sender, EventArgs e)
        {
            await LoadEmployee();
            await LoadRegion();
            await LoadTerritories();
        }

        private async void gdwEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
            {
                int employeeID = Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value);
                var employeeResult = await _employeeService.GetEmployee(e => e.EmployeeId == employeeID);
                if (employeeResult.Success == true)
                {
                    tbxLastName.Text = employeeResult.Data.LastName;
                    tbxFirstName.Text = employeeResult.Data.FirstName;
                    tbxTitle.Text = employeeResult.Data.Title;
                    tbxTitleOfCourtesy.Text = employeeResult.Data.TitleOfCourtesy;
                    dtpBirthDate.Value = employeeResult.Data.BirthDate != null ? employeeResult.Data.BirthDate.Value : DateTime.Now;
                    dtpHireDate.Value = employeeResult.Data.HireDate != null ? employeeResult.Data.HireDate.Value : DateTime.Now;
                    tbxAdress.Text = employeeResult.Data.Address;
                    cbxCity.SelectedIndex = cbxCity.FindString(employeeResult.Data.City);
                    cbxRegion.SelectedIndex = cbxRegion.FindString(employeeResult.Data.Region);
                    tbxPostalCode.Text = employeeResult.Data.PostalCode;
                    cbxCountry.SelectedIndex = cbxCountry.FindString(employeeResult.Data.Country != null ? employeeResult.Data.Country : "");
                    tbxPhone.Text = employeeResult.Data.HomePhone;
                    tbxExtension.Text = employeeResult.Data.Extension;
                    var imageResult = _utilitiesService.ByteToImage(employeeResult.Data.Photo);
                    if (imageResult.Success == true)
                    {
                        pictureBox.Image = imageResult.Data;
                    }
                    
                    rtbNote.Text = employeeResult.Data.Notes;
                }
                else
                    MessageBox.Show(employeeResult.Message);

            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {

            //if (gdwEmployee.CurrentRow.Cells[0].Value != null && !string.IsNullOrEmpty(gdwEmployee.CurrentRow.Cells[0].Value.ToString()))
            //{
            //    var employee = await _employeeDAL.GetAsync(gdwEmployee.CurrentRow.Cells[0].Value != null ? Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value) : 0);
            //    if (employee != null)
            //    {

            //        employee.LastName = tbxLastName.Text;
            //        employee.FirstName = tbxFirstName.Text;
            //        employee.Notes = rtbNote.Text;
            //        employee.Title = tbxTitle.Text;
            //        employee.TitleOfCourtesy = tbxTitleOfCourtesy.Text;
            //        employee.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
            //        employee.HireDate = Convert.ToDateTime(dtpHireDate.Text);
            //        employee.Region = cbxRegion.Text;
            //        employee.City = cbxCity.Text;
            //        employee.Country = cbxCountry.Text;
            //        employee.PostalCode = tbxPostalCode.Text;
            //        employee.HomePhone = tbxPhone.Text;
            //        employee.Extension = tbxExtension.Text;
            //        employee.Photo = utilities.imageToByte(pictureBox.Image, ImageFormat.Jpeg);

            //        _employeeDAL.UpdateAsync(employee);
            //        gdwEmployee.DataSource = await _employeeDAL.BindingList();
            //        MessageBox.Show(String.Format("{0} Id's employee has been updated.", employee.EmployeeId));
            //    }
            //    else
            //        MessageBox.Show("Record is not found...");
            //}
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
                int regionID = Convert.ToInt32(cbxRegion.SelectedValue);
                var result = await _employeeService.GetAllTerritories(t => t.RegionId == regionID);
                if (result.Success == true)
                {
                    cbxCity.DataSource = result.Data;
                }
                else
                    MessageBox.Show(result.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
             //var employee = await _employeeDAL.GetAsync(Convert.ToInt32(gdwEmployee.CurrentRow.Cells[0].Value != null ? gdwEmployee.CurrentRow.Cells[0].Value : 0));
            //    if (employee != null)
            //    {
            //        _employeeDAL.DeleteAsync(employee);
            //        gdwEmployee.DataSource = await _employeeDAL.BindingList();
            //        MessageBox.Show(String.Format("{0} Id's employee has been removed.", employee.EmployeeId));
            //    }
            //    else
            //    {
            //        MessageBox.Show("Record is not found...");
            //    }
        }

        public async Task LoadEmployee()
        {
            var result = await _employeeService.GetEmployees();
            if (result.Success == true)
            {
                gdwEmployee.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        public async Task LoadRegion()
        {
            var result = await _employeeService.GetAllRegion(null);
            if (result.Success == true)
            {
                cbxRegion.DataSource = result.Data;
                cbxRegion.DisplayMember = "RegionDescription";
                cbxRegion.ValueMember = "RegionID";
            }
            else
                MessageBox.Show(result.Message);
        }

        public async Task LoadTerritories()
        {
            var result = await _employeeService.GetAllTerritories(null);
            if (result.Success == true)
            {
                cbxCity.DataSource= result.Data;
                cbxCity.DisplayMember = "TerritoryDescription";
                cbxCity.ValueMember = "TerritoryID";
            }
            else
                MessageBox.Show(result.Message);
        }

    }
}
