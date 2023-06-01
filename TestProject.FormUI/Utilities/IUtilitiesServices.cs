using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TestProject.DataAccess.Concrete;

namespace TestProject.FormUI.Utilities
{
    internal interface IUtilitiesServices
    {
        void TextBoxClear(params TextBox[] textBoxes);
        void RichTextBoxClear(params RichTextBox[] richTextBoxes);
        Result<Image> ByteToImage(byte[] bytes);
        Result<byte[]> ImageToByte(Image image, ImageFormat imageFormat);
    }
}
