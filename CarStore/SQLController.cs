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

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\_Ctrl_\Documents\Cars.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection connection;

        public SQLController()
        {
            connection = new SqlConnection(connectionString);
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
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
