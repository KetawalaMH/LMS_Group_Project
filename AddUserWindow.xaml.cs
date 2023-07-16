using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private UserVM UserviewModel;
        private AdminVM AdminviewModel;
        public AddUserWindow()
        {
            InitializeComponent();

            UserviewModel = new UserVM();
            AdminviewModel = new AdminVM();
        }


        private void Add_User_Click(object sender, RoutedEventArgs e)
        {
            string username = User_IDtext.Text;
            string password = User_PasswordText.Text;

            User newUser = new User
            {
                Name = username,
                Password = password
                // Set other user properties as needed
            };

            UserviewModel.AddUser(newUser);

            MessageBox.Show("User added successfully!");

            Close();

        }

        private void Add_Admin_Click(object sender, RoutedEventArgs e)
        {
            string username = User_IDtext.Text;
            string password = User_PasswordText.Text;

            Admin newAdmin = new Admin
            {
                Admin_Name = username,
                Admin_Password = password
                // Set other user properties as needed
            };

            AdminviewModel.AddAdmin(newAdmin);

            MessageBox.Show("User added successfully!");

            Close();

        }

    }
}
