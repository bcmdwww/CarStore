using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarShop
{
    static class Converter
    {
        public static System.Windows.Controls.Image BinaryToImage(byte[] data)
        {
            
                BitmapImage BitmapImage = new BitmapImage();
                BitmapImage.BeginInit();
                BitmapImage.StreamSource = new System.IO.MemoryStream(data);
                BitmapImage.EndInit();
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = BitmapImage;
                return image;
            
            
            //image.Source = Image.FromStream(ms);//(BitmapImage)Image.FromStream(ms);
            
        }

        public static byte[] FileToBinary(Uri uriImg)
        {
            using (FileStream fs = new FileStream(uriImg.AbsolutePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                return br.ReadBytes((int)fs.Length);
            }
        }

    }
}
