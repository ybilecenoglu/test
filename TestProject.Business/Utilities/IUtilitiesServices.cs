using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business.Utilities
{
    public interface IUtilitiesServices
    {
        void RichTextBoxClear(params RichTextBox[] richTextBoxes);
        void TextBoxClear(params TextBox[] textBoxes);
        Result<Image> ByteToImage(byte[] bytes);
        Result<byte[]> ImageToByte(Image image, ImageFormat imageFormat);
    }
}
