using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarShop
{
    class SQLController
    {
        string connectionStr;
        public SqlConnection connection;
  
        public SQLController()
        {
                connection = new SqlConnection(GetFileDir());
        }

        public bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public bool Disconnect()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public void Update(ref Controller ctr)
        {
            string sql = "SELECT * FROM CarsTable";
            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<DataItem> buf = new List<DataItem>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            buf.Add(new DataItem(
                                (int)reader.GetValue(0),
                                (string)reader.GetValue(1),
                                (string)reader.GetValue(2),
                                (int)reader.GetValue(3),
                                 Converter.BinaryToImage((byte[])reader.GetValue(4))));
                        }
                    }
                    reader.Close();
                    foreach (var element in buf)
                    {
                        ctr.AddItem(element);
                    }
                }
                else
                {
                    throw new Exception("Server doesn't connect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private string GetFileDir()
        {
            try
            {
                string connectionString;
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Title = "Chose database";
                myDialog.Filter = "database(*.mdf)|*.MDF" + "|Все файлы (*.*)|*.* ";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true)
                {
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + myDialog.FileName + ";Integrated Security=True;Connect Timeout=30";
                    return connectionString;
                }
                else
                {
                    throw new Exception("the empty choise");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return @"Empty connection string!"; 
            }
        }
            
    }
}
