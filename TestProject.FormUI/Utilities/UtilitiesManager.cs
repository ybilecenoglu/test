using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.DataAccess.Concrete;
using TestProject.FormUI.Utilities;

namespace TestProject.Business
{
    internal class UtilitiesManager : IUtilitiesServices
    {
        public Result<Image> ByteToImage(byte[] bytes)
        {
            var result = new Result<Image>() { Success = false };
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    result.Success = true;
                    result.Message = "Success";
                    result.Data = image;

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;

                return result;
            }
        }

        public Result<byte[]> ImageToByte(Image image, ImageFormat imageFormat)
        {
            var result = new Result<byte[]>() { Success = false };
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var bitMap = new Bitmap(image);
                    bitMap.Save(ms, imageFormat);
                    result.Success = true;
                    result.Message = "Success";
                    result.Data = ms.ToArray();

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message += ex.Message;
                return result;
            }
        }

        //Hata döndüren global try catch method
        //    public void exceptionHandler(Action action)
        //    {
        //        try
        //        {
        //            action.Invoke();
        //        }
        //        catch (DbUpdateConcurrencyException exception)
        //        {
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                AppErrorLog log = new AppErrorLog();
        //                log.Message = exception.Message;
        //                log.Date = DateTime.Now;
        //                log.Action = action.Method.Name;
        //                log.Target = action.Target.ToString();
        //                context.AppErrorLogs.Add(log);
        //                context.SaveChanges();
        //                System.Windows.Forms.MessageBox.Show(exception.Message);
        //            }
        //        }
        //    }
        public void TextBoxClear(params TextBox[] textBoxes)
        {
            foreach (var textbox in textBoxes)
            {
                textbox.Clear();
            }
        }
    }
}
