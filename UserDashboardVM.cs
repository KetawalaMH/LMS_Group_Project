using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project
{
    public partial class UserDashboardVM :ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
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
                string name = SelectedStudent.StudentID;
                Students.Remove(SelectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

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

        public UserDashboardVM()
        {
            // Initialize the students collection by retrieving data from the student table in the database
            LoadStudents();
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


    }
}
