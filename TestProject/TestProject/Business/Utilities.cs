using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Database;
using TestProject.Models;

namespace TestProject.Business
{
    internal class Utilities
    {
        public List<T> buildList<T>(params T[] values)
        {
            return new List<T>(values);
        }
        public async void returnExc(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show(exception.Message);
                using (NorthwindContext context = new NorthwindContext())
                {
                    AppLog log = new AppLog();
                    log.Message = exception.Message;
                    log.Date = DateTime.Now;

                    context.AppLogs.Add(log);
                    await context.SaveChangesAsync();
                }
            }
        }

        public void clearTextBox(params TextBox[] textBoxes)
        {
            foreach (var item in textBoxes)
            {
                item.Clear();
            }
        }
        public void unCheckedRadioBtn(params RadioButton[] radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                radioButton.Checked = false;
            }
        }

        public Image byteToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                int offSet = 78;
                ms.Write(bytes,offSet,bytes.Length-offSet);
                Image img = Image.FromStream(ms);
                return img;
            }
        }

        public byte[] imageToByte(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
