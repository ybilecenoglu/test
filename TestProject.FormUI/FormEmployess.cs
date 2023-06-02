using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.Entities.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject
{
    public partial class FormEmployess : Form
    {

        private IEmployeeService _employeeService;
        private IConvertImageService _convertImageService;
        private IFormItemClearService _formItemClearService;
        public FormEmployess()
        {
            InitializeComponent();
            _employeeService = InstanceFactory.GetInstance<EmployeeManager>();
            _convertImageService = InstanceFactory.GetInstance<ConvertImageManager>();
            _formItemClearService = new FormItemClearManager();
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
                    tbxEmployeeId.Text = employeeResult.Data.EmployeeId.ToString();
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
        private async void btnRemove_Click(object sender, EventArgs e)
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
                        await LoadEmployee();
                    }
                    else
                        MessageBox.Show(deleteResult.Message);
                }
            }
            else
                MessageBox.Show("Kayıt bulunamadı...");
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
        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            var result = await _employeeService.GetEmployees(e => e.FirstName.Contains(tbxSearch.Text.ToLower()));
            if (result.Success == true)
            {
                gdwEmployee.DataSource = result.Data;
            }
            else
                MessageBox.Show(result.Message);
        }
        private async void btnAddOrUpdate_Click(object sender, EventArgs e)
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
                    employeeResult.Data.Region = cbxRegion.Text;
                    employeeResult.Data.City = cbxCity.Text;
                    employeeResult.Data.Country = cbxCountry.Text;
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
                        await LoadEmployee();
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
                employee.Region = cbxRegion.Text;
                employee.City = cbxCity.Text;
                employee.Country = cbxCountry.Text;
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
                    await LoadEmployee();
                }
                else
                    MessageBox.Show(addResult.Message);
            }
        }
        private void btnChooseClear_Click(object sender, EventArgs e)
        {
            _formItemClearService.TextBoxClear(tbxEmployeeId, tbxAdress, tbxExtension, tbxFirstName, tbxLastName, tbxPhone, tbxPostalCode, tbxTitle, tbxTitleOfCourtesy);
            _formItemClearService.RichTextBoxClear(rtbNote);
            _formItemClearService.PictureBoxClear(pictureBox);
            gdwEmployee.ClearSelection();
        }
    }
}
