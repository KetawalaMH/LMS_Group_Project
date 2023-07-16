using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for CreateStudentWindow.xaml
    /// </summary>
    public partial class CreateStudentWindow : Window
    {
        private StudentVM viewModel;

        public CreateStudentWindow()
        {
            InitializeComponent();

            viewModel = new StudentVM();
            DataContext = viewModel;

            // Load modules based on the selected semester
           
        }

        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
          
            //viewModel.LoadModulesFromDatabase();
            SelectModuleWindow selectmodule = new SelectModuleWindow();
            selectmodule.Show();
        }

        private void SaveStudent_Click(object sender, RoutedEventArgs e)
        {
            string StudentID = StudentIDTxt.Text;
            string StudentName = StudentNameTxt.Text;
            string age = StudentAgeTxt.Text;
            string StudentAddress = StudentAddressTxt.Text;
            string Semester = CurrentSemesterTxt.Text;

            Student newstudent = new Student
            {
                StudentID = StudentID,
                StudentName = StudentName,
                age = age,
                GPA = 0,
                StudentAddress = StudentAddress,
                Semester = Semester


            };

            viewModel.AddStudent(newstudent);
            MessageBox.Show("Student Account Created successfully!");
            Close();
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();

        }
    }
}
