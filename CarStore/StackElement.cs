using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CarShop
{
    class StackElement
    {
        public Grid MainGrid;
        public StackElement(String _carName,String _carInfo,int _price,Image _image)
        {
            MainGrid = new Grid
            {
                ShowGridLines = true,
                Background = Brushes.LightGray,
                Width = 300,
                Margin = new Thickness(5),
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(30) },
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(30) }
                },
                ColumnDefinitions = {new ColumnDefinition()}
            };
            _image.StretchDirection = StretchDirection.Both;
            _image.Stretch = Stretch.UniformToFill;
            _image.VerticalAlignment = VerticalAlignment.Center;
            _image.HorizontalAlignment = HorizontalAlignment.Center;
            MainGrid.Children.Add(_image);
            Grid.SetRow(_image, 0);

            TextBlock t_tbName = new TextBlock { Text = _carName };
            MainGrid.Children.Add(t_tbName);
            Grid.SetRow(t_tbName, 1);

            TextBlock t_tbInfo = new TextBlock { Text = _carInfo };
            MainGrid.Children.Add(t_tbInfo);
            Grid.SetRow(t_tbInfo, 2);

            Grid ChildGrid = new Grid
            {
                ShowGridLines = true,
                Background = Brushes.White,
                RowDefinitions = { new RowDefinition() },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };
            Grid.SetRow(ChildGrid, 3);
            MainGrid.Children.Add(ChildGrid);
            
            TextBlock t_tbPrice = new TextBlock { Text = _price.ToString() + "$" };
            ChildGrid.Children.Add(t_tbPrice);
            Grid.SetColumn(t_tbPrice, 0);
            Button Button = new Button { Content = "TO ISSUE", Background = Brushes.WhiteSmoke };
            ChildGrid.Children.Add(Button);
            Grid.SetColumn(Button, 1);
            Button.Click += Button_click; 
        }
        public void ClearReference()
        {
            MainGrid.Children.Clear();
            
        }
        void Button_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
