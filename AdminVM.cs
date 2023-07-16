using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class AdminVM
    {
        private SQLiteConnection connection;

        public AdminVM()
        {
            UserDataContext dataContext = new UserDataContext();
           
            string ConnectionString = $"Data Source={dataContext.path}";
            connection = new SQLiteConnection(ConnectionString);
            // Initialize the connection and perform any other necessary setup
        }

        public void AddAdmin(Admin admin)
        {
            string query = "INSERT INTO Admins (Admin_Name, Admin_Password) VALUES (@Admin_Name, @Admin_Password)";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            // Set the parameter values
            command.Parameters.AddWithValue("@Admin_Name", admin.Admin_Name);
            command.Parameters.AddWithValue("@Admin_Password", admin.Admin_Password);

            // Execute the query
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool AuthenticateAdmin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Admins WHERE Admin_Name = @Admin_Name AND Admin_Password = @Admin_Password";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@Admin_Name", username);
            command.Parameters.AddWithValue("@Admin_Password", password);

            connection.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return count > 0;
        }
    }
}
