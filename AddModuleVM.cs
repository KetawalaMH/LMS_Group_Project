using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Group_Project
{
    public partial class AddModuleVM : ObservableObject
    {
        [ObservableProperty]
        public string modulecode;

        [ObservableProperty]
        public string modulename;
        [ObservableProperty]
        public string department;
        [ObservableProperty]
        public string semester;
        [ObservableProperty]
        public int credits;

        public AddModuleVM(Module m)
        {
            modulecode = m.ModuleCode;
            modulename = m.ModuleName;
            department = m.Department;
            semester = m.Semester;
            credits = m.Credits;

        }
        private SQLiteConnection connection;

        public AddModuleVM()
        {
            // public readonly string path = @"C:\Users\Malshan\source\repos\Group Project\Group Project\LMSDataBase.db";
            UserDataContext dataContext = new UserDataContext();
           
            string ConnectionString = $"Data Source={dataContext.path}";
            connection = new SQLiteConnection(ConnectionString);
            // Initialize the connection and perform any other necessary setup
        }

        public Module Module { get; private set; }

        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void AddModule(Module Module)
        {

            string query = "INSERT INTO Modules (Modulecode, Modulename, Department, Semester, Credits) VALUES (@Modulecode, @Modulename, @Department, @Semester, @Credits)";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            // Set the parameter values
            command.Parameters.AddWithValue("@Modulecode", Module.ModuleCode);
            command.Parameters.AddWithValue("@Modulename", Module.ModuleName);
            command.Parameters.AddWithValue("@Department", Module.Department);
            command.Parameters.AddWithValue("@Semester", Module.Semester);
            command.Parameters.AddWithValue("@Credits", Module.Credits);

            // Execute the query
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        
    }
}
