using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project
{
    public partial class UserVM: ObservableObject
    {
        private SQLiteConnection connection;

        public UserVM()
        {
            //public readonly string path = @"C:\Users\Malshan\Desktop\Group_Project";


            UserDataContext dataContext = new UserDataContext();
            string ConnectionString = $"Data Source={dataContext.path}";
            connection = new SQLiteConnection(ConnectionString);
            // Initialize the connection and perform any other necessary setup
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO Users (Name, Password) VALUES (@Name, @Password)";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            // Set the parameter values
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Password", user.Password);

            // Execute the query
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@Name", username);
            command.Parameters.AddWithValue("@Password", password);

            connection.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return count > 0;
        }

    }
}
