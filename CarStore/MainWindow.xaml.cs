using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private StackElement element;
        //sp_ViewaArea.Children.Add(new TabPanel { Width = 300, Margin = new Thickness(10), Background = randBrush(), Opacity = 0.3});
        public MainWindow()
        {
            InitializeComponent();
            element = new StackElement("Nissan Skyline R32 GT-R V-Spec",
                "Twin-turbo, 2.6-liter inline-six.\n"+
                "276 horsepower.\n"+
                "271 pound - feet.\n" +
                "Unofficially rated at 316 horses.\n" +
                "0 to 62 mph in 4.7 seconds.\n"+
                "All - wheel drive.\n" +
                "Top speed at more than 150 mph.\n" +
                "Nurburgring record in the 1980s.",
                10000, new Image());
            sp_ViewaArea.Children.Add(element.MainGrid);
        }

        
        
        private Brush randBrush()
        {
            Random rnd = new Random();
            int k = rnd.Next(0,8);
            switch (k)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.White;
                case 2:
                    return Brushes.Red;
                case 3:
                    return Brushes.Orange;
                case 4:
                    return Brushes.Yellow;
                case 5:
                    return Brushes.Green;
                case 6:
                    return Brushes.Blue;
                case 7:
                    return Brushes.DarkBlue;
                case 8:
                    return Brushes.Violet;
                default:
                    return Brushes.White;
            }
        }
    }
}
