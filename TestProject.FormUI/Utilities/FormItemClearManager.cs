using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public async void ComboBoxClear(params ComboBox[] comboBoxes)
        {
            await _ExceptionHandlerService.ReturnException(async () =>
            {
                foreach (var comboBox in comboBoxes)
                {
                    comboBox.SelectedIndex = -1;
                }
            });
        }

        public async void PictureBoxClear(params PictureBox[] pictureBoxes)
        {
            await _ExceptionHandlerService.ReturnException(async () =>
            {
                foreach (var pictureBox in pictureBoxes)
                {
                    pictureBox.Image = null;
                }
            });
        }

        public async void RadioButtonClear(params RadioButton[] radioButtons)
        {
            await _ExceptionHandlerService.ReturnException(async () =>
            {
                foreach (var radioButton in radioButtons)
                {
                    radioButton.Checked = false;
                }
            });
        }

        public async void RichTextBoxClear(params RichTextBox[] richTextBoxes)
        {
            await _ExceptionHandlerService.ReturnException(async () =>
            {
                foreach (var richTextBox in richTextBoxes)
                {
                    richTextBox.Clear();
                }
            });
        }

        public async void TextBoxClear(params TextBox[] textBoxes)
        {
            await _ExceptionHandlerService.ReturnException(async () =>
            {
                foreach (var textBox in textBoxes)
                {
                    textBox.Clear();
                }
            });
        }

    }
}
