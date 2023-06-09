using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business.Utilities;

namespace TestProject.FormUI.Utilities
{
    public class FormItemClearManager : IFormItemClearService
    {

        private static FormItemClearManager _FormItemClearManager;
        private IExceptionHandlerService _ExceptionHandlerService;
        private FormItemClearManager()
        {
            _ExceptionHandlerService = new ExceptionHandlerManager();
        }

        //Create singleton method
        public static FormItemClearManager CreateAsFormItemClearManager()
        {
            return _FormItemClearManager ?? (_FormItemClearManager = new FormItemClearManager());
        }
        public void ComboBoxClear(params ComboBox[] comboBoxes)
        {
            try
            {
                foreach (var comboBox in comboBoxes)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void PictureBoxClear(params PictureBox[] pictureBoxes)
        {
            try
            {
                foreach (var pictureBox in pictureBoxes)
                {
                    pictureBox.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void RadioButtonClear(params RadioButton[] radioButtons)
        {
            try
            {
                foreach (var radioButton in radioButtons)
                {
                    radioButton.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        public void RichTextBoxClear(params RichTextBox[] richTextBoxes)
        {

            try
            {
                foreach (var richTextBox in richTextBoxes)
                {
                    richTextBox.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void TextBoxClear(params TextBox[] textBoxes)
        {
            try
            {
                foreach (var textBox in textBoxes)
                {
                    textBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

    }
}
