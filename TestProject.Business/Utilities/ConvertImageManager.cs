﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business
{
    public class ConvertImageManager
    {
        private static ConvertImageManager instance;

        public static ConvertImageManager CreateInstance()
        {
            return instance ?? (instance = new ConvertImageManager());
        }
        public Result<Image> ByteToImage(byte[] bytes)
        {
            var result = new Result<Image>() { Success = false };
            try
            {
                    ImageConverter converter= new ImageConverter();
                    Image image = (Image)converter.ConvertFrom(bytes);
                    result.Success = true;
                    result.Message = "Success";
                    result.Data = image;

                    return result;
                
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

    }
}
