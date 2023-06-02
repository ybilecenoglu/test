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
        public void ComboBoxClear(params ComboBox[] comboBoxes)
        {
            try
            {
                foreach (var comboBox in comboBoxes)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {

                throw new Exception("Picture box temizleme işlemi başarısız oldu.");
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
            catch (Exception)
            {

                throw new Exception("Picture box temizleme işlemi başarısız oldu.");
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
            catch (Exception)
            {
                throw new Exception("Radio button temizleme işlemi başarısız oldu.");
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
            catch (Exception)
            {

                throw new Exception("Rich text box temizleme işlemi başarısız oldu.");
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
            catch (Exception)
            {

                throw new Exception("Text box temizleme işlemi başarısız oldu.");
            }
        }

    }
}
