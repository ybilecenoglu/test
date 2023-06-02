using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject.FormUI.Utilities
{
    public interface IFormItemClearService
    {
        void TextBoxClear(params TextBox[] textBoxes);
        void RichTextBoxClear(params RichTextBox[] richTextBoxes);
        void PictureBoxClear(params PictureBox[] pictureBoxes);
        void RadioButtonClear(params RadioButton[] radioButtons);
        void ComboBoxClear(params ComboBox[] comboBoxes);
    }
}
