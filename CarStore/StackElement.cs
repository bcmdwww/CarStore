using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace CarShop
{
    class StackElement
    {
        public Grid MainGrid;
        public StackElement(String _carName,String _carInfo,int _price,Image _image)
        {
            MainGrid = new Grid { Background = Brushes.Azure,
                
                Width = 300,
                Margin = new Thickness(5),
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(30) },
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(30) }
                },
                ColumnDefinitions = { new ColumnDefinition() }
            };
            MainGrid.Children.Add(_image);
            Grid.SetRow(_image, 0);
            TextBlock t_tbName = new TextBlock { Text = _carName };
            MainGrid.Children.Add(t_tbName);
            Grid.SetRow(t_tbName, 1);

            TextBlock t_tbInfo = new TextBlock { Text = _carInfo };
            MainGrid.Children.Add(t_tbInfo);
            Grid.SetRow(t_tbInfo, 2);
        }
    }
}
