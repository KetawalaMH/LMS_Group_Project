using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Group_Project
{
    public partial class StudentVM : ObservableObject
    {
        private SQLiteConnection connection;
        public StudentVM()
        {
            // Initialize the connection object
            UserDataContext dataContext = new UserDataContext();
            string connectionString = $"Data Source={dataContext.path}"; // Replace with your SQLite connection string
            connection = new SQLiteConnection(connectionString);
           // LoadModulesFromDatabase();
        }
        public ObservableCollection<Module> StudentsModules { get; set; } = new ObservableCollection<Module>();
        public Student SelectedStudent { get; set; }

        // Other properties and methods
        public void AddStudent(Student student)
        {
            // Insert the student into the Students table
            string insertQuery = "INSERT INTO Students (StudentID, StudentName, age,  GPA,  Semester, StudentAddress) VALUES (@StudentID, @StudentName, @age, @GPA, @Semester, @StudentAddress)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@StudentID", student.StudentID);
            insertCommand.Parameters.AddWithValue("@StudentName", student.StudentName);
            insertCommand.Parameters.AddWithValue("@age", student.age);
            insertCommand.Parameters.AddWithValue("@GPA", student.GPA);
            insertCommand.Parameters.AddWithValue("@Semester", student.Semester);
            insertCommand.Parameters.AddWithValue("@StudentAddress", student.StudentAddress);
            
            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();

            // Insert the selected modules into the junction table
           /* foreach (Module module in student.Modules)
            {
                string insertModuleQuery = "INSERT INTO StudentModules (StudentId, ModuleId) VALUES (@StudentId, @ModuleId)";
                SQLiteCommand insertModuleCommand = new SQLiteCommand(insertModuleQuery, connection);
                insertModuleCommand.Parameters.AddWithValue("@StudentId", studentId);
                insertModuleCommand.Parameters.AddWithValue("@ModuleId", module.ModuleCode);
                connection.Open();
                insertModuleCommand.ExecuteNonQuery();
                connection.Close();
            }
        }


        public ObservableCollection<Module> Modules { get; set; } = new ObservableCollection<Module>();

        // Populate the Modules collection with data from the database
        public void LoadModulesFromDatabase()
        {
            using (UserDataContext dataContext = new UserDataContext())
            {
                var modules = dataContext.Modules.ToList();
                Modules.Clear();
                foreach (var module in modules)
                {
                    Modules.Add(module);
                }
            }*/
        }

        public void UpdateStudent(Student student)
        {
            // Check if the student exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Students WHERE StudentID = @StudentID";
            using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@StudentID", student.StudentID);
                connection.Open();
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                connection.Close();

                if (count == 0)
                {
                    // Student doesn't exist, perform appropriate action (e.g., display error message)
                    // Handle the scenario when the student doesn't exist in the database
                    return;
                }
            }

            // Update the student in the Students table
            string updateQuery = "UPDATE Students SET StudentName = @StudentName, Age = @Age, Semester = @Semester WHERE StudentID = @StudentID";
            using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@StudentName", student.StudentName);
                updateCommand.Parameters.AddWithValue("@Age", student.age);
                updateCommand.Parameters.AddWithValue("@Semester", student.Semester);
                updateCommand.Parameters.AddWithValue("@StudentID", student.StudentID);

                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteStudent(Student student)
        {
            // Delete the student from the Students table
            string deleteQuery = "DELETE FROM Students WHERE StudentID = @StudentID";
            using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@StudentID", student.StudentID);

                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Student GetStudentDetails(int studentID)
        {
            // Retrieve the student details from the Students table
            string selectQuery = "SELECT * FROM Students WHERE StudentID = @StudentID";
            using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@StudentID", studentID);

                connection.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();

                Student student = null;

                if (reader.Read())
                {
                    student = new Student
                    {
                        StudentID = reader["StudentID"].ToString(),
                        StudentName = reader["StudentName"].ToString(),
                        age = reader["Age"].ToString(),
                        Semester = reader["Semester"].ToString()
                        // Set other student properties as needed
                    };
                }

                reader.Close();
                connection.Close();

                return student;
            }
        }


    }
}
