using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Group_Project
{
    public partial class UpdateStudentVM : ObservableObject
    {

        private SQLiteConnection connection;
       
        [ObservableProperty]
        public string studentID;


        [ObservableProperty]
        public string studentname;

        [ObservableProperty]
        public string age;

        [ObservableProperty]
        public string address;

        [ObservableProperty]
        public double gPA;
        [ObservableProperty]
        public string semester;



        //To change the tile



        [ObservableProperty]
        public string title;


        public UpdateStudentVM()
        {
            

        }

        public UpdateStudentVM(Student u)
        {
            Student = u;
            

            studentID = Student.StudentID;
            studentname = Student.StudentName;
            gPA = Student.GPA;
            address = Student.StudentAddress;
            semester = Student.Semester;
            age = Student.age;

            UserDataContext dataContext = new UserDataContext();
            string connectionString = $"Data Source={dataContext.path}"; // Replace with your SQLite connection string
            connection = new SQLiteConnection(connectionString);
        }

      
        

        public Student Student { get; private set; }
        public Student Student1 { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {
                Student.StudentID = studentID;
                Student.StudentName = studentname;
                Student.age = age;
                Student.StudentAddress = address;
                Student.Semester = semester;

                UpdateStudent(Student);

            if (Student.StudentID != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


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

                if (count != 0)
                {
                    
                    string updateQuery = "UPDATE Students SET StudentName = @StudentName, Age = @Age, Semester = @Semester WHERE StudentID = @Student1ID";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@StudentName", student.StudentName);
                        updateCommand.Parameters.AddWithValue("@Age", student.age);
                        updateCommand.Parameters.AddWithValue("@Semester", student.Semester);
                        updateCommand.Parameters.AddWithValue("@Student1ID", student.StudentID);

                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Updated");
                        connection.Close();
                    }
                    // Student doesn't exist, perform appropriate action (e.g., display error message)
                    // Handle the scenario when the student doesn't exist in the database
                   
                }
                else {
                    MessageBox.Show("Select a student to update");
                    return;
                }
            }

            // Update the student in the Students table
            
        }
    }

}
