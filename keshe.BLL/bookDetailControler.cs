using keshe.DAL;
using keshe.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace keshe.BLL
{
    public sealed class bookDetailControler
    {
        /// <summary>
        /// 此类为添加图书界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private bookDetailControler() { }
        public static Book GetBookbybkID(Int32 bkID)
        {
            return BookDAL.GetObjectByID(bkID);
        }
        /// <summary>
        /// Image转byte[]
        /// </summary>
        public static byte[] ImageToByte(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        /// <summary>
        /// byte[]转Image
        /// </summary>
        public static Image ByteToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
    }
}
