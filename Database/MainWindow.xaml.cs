/*
 * Name: Jennifer Huestis
 * File: MinWindow.xaml.cs
 * Date: 02/10/2020
 * Description: This file gives functionality to the text boxes and buttons. Here, the database is accessed, and the information 
 *  is diplayed with the click of a button.
 */

using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"|DataDirectory|Employee Database.accdb\"");
        }

        private void assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "EmployeeID: " + read[0].ToString() + ", AssetID: " + read[1].ToString() + ", Description: " + read[2].ToString() + "\n";
                typeHere1.Text = data;
            }
            cn.Close();

        }
        private void employees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "EmployeeID: " + read[0].ToString() + "\nName: " + read[1].ToString() + " " + read[2].ToString() + "\n\n";
                typeHere2.Text = data;
            }
            cn.Close();
        }

        private void typeHere2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void typeHere1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
