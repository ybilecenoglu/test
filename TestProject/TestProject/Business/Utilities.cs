﻿using System;
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

        //Hata döndüren global try catch method
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

        public void clearRichTextBox(params RichTextBox[] richTextBoxes)
        {
            foreach (var item in richTextBoxes)
            {
                item.Clear();
            }
        }

        //Byte tipini image dönüştüren method
        public Image byteToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes,0,bytes.Length))
            {
                Image image =Image.FromStream(ms,true);
                return image;
            }
        }

        //Imagelari byte dönüştüren method
        public byte[] imageToByte(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes =ms.ToArray();

                return imageBytes;
            }
        }
    }
}
