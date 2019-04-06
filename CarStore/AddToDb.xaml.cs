using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddToDb : Window
    {
        SqlConnection connection;
        BitmapImage bitmap;
        Uri uriImg;
        public AddToDb(SqlConnection sqlDB)
        {
            InitializeComponent();
            Image.Source = new BitmapImage();
            connection = sqlDB;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(Image.Source == null || tb_CarInfo.Text.Equals("") || tb_CarName.Text.Equals("") || tb_CarPrice.Text.Equals("")))
                {
                    byte[] img = Converter.FileToBinary(uriImg);
                    string sql = "INSERT INTO CarsTable(CarName,CarInfo,Price,Image)VALUES('" +
                        tb_CarName.Text + "','" +
                        tb_CarInfo.Text + "'," +
                        tb_CarPrice.Text + ",@img)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    command.ExecuteNonQuery();
                    this.Close();
                }
                else
                    throw new Exception("Not all fields is changed");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            if (myDialog.ShowDialog() == true)
            {
                string selectedFileName = myDialog.FileName;

                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                uriImg = bitmap.UriSource;
                bitmap.EndInit();
                Image.Source = bitmap;
            }
        }
    }
}
