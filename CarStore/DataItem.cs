using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CarShop
{
    class DataItem
    {
        public int CarId;
        public String CarName;
        public String CarInfo;
        public int Price;
        public Image Image;
        public DataItem(int CarID, String CarName, String CarInfo,int Price, Image Image)
        {
            this.CarId = CarID;
            this.CarName = CarName;
            this.CarInfo = CarInfo;
            this.Price = Price;
            this.Image = Image;
        }
    }
}
