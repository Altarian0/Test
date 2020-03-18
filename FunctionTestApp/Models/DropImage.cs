using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FunctionTestApp.Models
{
    public class DropImage
    {
     
        public string Uri { get; set; }
        public string ImageStr
        {
            get
            {
                return Uri;
            }
        }
        public string Text
        {
            get
            {
                string[] names = Uri.Split(new char[] { '\\' });
                return names[names.Length - 1 ];
            }
        }
        public BitmapImage ImageSrc
        {
            get
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(Uri, UriKind.RelativeOrAbsolute);
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}
