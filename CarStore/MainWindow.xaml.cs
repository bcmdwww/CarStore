using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        
        private Controller controller;
        internal SQLController sqlDB;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
            sqlDB = new SQLController();
            
        }
        
        private void Bt_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (sqlDB.connection == null || sqlDB.connection.State == ConnectionState.Closed)
            {
                if (sqlDB.Connect())
                {
                    tb_status.Text = sqlDB.connection.State.ToString();
                    bt_Connect.Content = "Close DB";
                    bt_Connect.Background = Brushes.Green;
                    sqlDB.Update(ref controller);
                    UpdateStackView();
                }
                return;
            }
            else if (sqlDB.connection.State == ConnectionState.Open)
            {
                if (sqlDB.Disconnect())
                {
                    tb_status.Text = sqlDB.connection.State.ToString();
                    bt_Connect.Content = "Connect to DB";
                    bt_Connect.Background = Brushes.Red;
                    controller.Clear();
                    UpdateStackView();
                }
               return;
            }
            
        }

        private void Bt_add_Click(object sender, RoutedEventArgs e)
        {
            if (sqlDB.connection == null || sqlDB.connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("DataBase is disconnected");
                return;
            }
            AddToDb Window = new AddToDb(sqlDB.connection);
            Window.ShowDialog();
            sqlDB.Update(ref controller);
        }

        private void UpdateStackView()
        {
            if(controller.ReturnAll().Count == 0)
            {
                sp_ViewaArea.Children.Clear();
            }
            foreach (var element in controller.ReturnAll())
            {
                sp_ViewaArea.Children.Add(new StackElement(element.CarName,element.CarInfo,element.Price, element.Image).MainGrid);
            }
        }

        private void Tbx_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sqlDB != null) {
                if (!tbx_Search.Text.Equals(""))
                {
                    foreach(var element in sp_ViewaArea.Children)
                    {
                        (element as Grid).Children.Clear() ;
                    }
                    sp_ViewaArea.Children.Clear();
                    foreach (var element in controller.FindItem(tbx_Search.Text))
                    {
                        sp_ViewaArea.Children.Add(new StackElement(element.CarName, element.CarInfo, element.Price, element.Image).MainGrid);
                    }
                }
                else
                {
                    foreach (var element in sp_ViewaArea.Children)
                    {
                        (element as Grid).Children.Clear();
                    }
                    sp_ViewaArea.Children.Clear();
                    UpdateStackView();
                }
            }
        }
    }
}
