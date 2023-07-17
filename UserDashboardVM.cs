using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Group_Project
{
    public partial class UserDashboardVM :ObservableObject
    {
        private SQLiteConnection connection;
        [ObservableProperty]
        public ObservableCollection<Student> students;
       [ObservableProperty]
        public Student selectedStudent = null;


        
        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void Messeag()
        {

            MessageBox.Show($"{SelectedStudent.StudentName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new CrewateStudentVM();
            vm.Title = "ADD STUDENT";
            

            if (vm.Student.StudentID != null)
            {
                Students.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent != null)
            {
                string deleteQuery = "DELETE FROM Students WHERE StudentID = @StudentID";
                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@StudentID", SelectedStudent.StudentID);

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                    string name = SelectedStudent.StudentID;
                    Students.Remove(SelectedStudent);
                    MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
                }
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (SelectedStudent != null)
            {
                var vm = new CrewateStudentVM(SelectedStudent);
                vm.Title = "EDIT STUDENT";
               

                


                int index = Students.IndexOf(SelectedStudent);
                Students.RemoveAt(index);
                Students.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        

        private void LoadStudents()
        {
            // Retrieve the students from the student table in the database and populate the Students collection
            
            Students = new ObservableCollection<Student>(GetStudentsFromDatabase());
        }

        private static IEnumerable<Student> GetStudentsFromDatabase()
        {
            // Retrieve the student data from the student table in the database
            // and return the result as a collection of Student objects

           
            using (var dbContext = new UserDataContext())
            {
                return dbContext.Students.ToList();
            }
        }

        public UserDashboardVM()
        {
            // Initialize the students collection by retrieving data from the student table in the database
            LoadStudents();
            UserDataContext dataContext = new UserDataContext();
            string connectionString = $"Data Source={dataContext.path}"; // Replace with your SQLite connection string
            connection = new SQLiteConnection(connectionString);
        }

    }
}
