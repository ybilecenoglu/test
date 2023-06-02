using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business.Utilities
{
    public interface IConvertImageService
    {
        Result<Image> ByteToImage(byte[] bytes);
        Result<byte[]> ImageToByte(Image image, ImageFormat imageFormat);
    }
}
