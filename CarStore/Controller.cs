using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarShop
{
    class Controller 
    {
        private List<DataItem> dataItems;
        public Controller()
        {
            dataItems = new List<DataItem>();
        }
        public void AddItem(DataItem dataItem)
        {
            dataItems.Add(dataItem);
        }
        public List<DataItem> ReturnAll()
        {
            return dataItems;
        }
        public List<DataItem> FindItem(String targetText)
        {
            List<DataItem> currentList = new List<DataItem>();
            foreach(var element in dataItems)
            {
                if (element.CarName.ToLower().Contains(targetText.ToLower())) currentList.Add(element);
                else if (element.CarInfo.ToLower().Contains(targetText.ToLower())) currentList.Add(element);
                else if (element.Price.ToString().Contains(targetText)) currentList.Add(element);
            }
            if(currentList.Count != 0)
            {
                return currentList;
            }

            return new List<DataItem>();
        }
        public void Clear()
        {
            dataItems.Clear();
        }
    }
}
