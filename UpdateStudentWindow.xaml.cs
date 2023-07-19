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
    /// Interaction logic for UpdateStudentWindow.xaml
    /// </summary>
    public partial class UpdateStudentWindow : Window
    {
        //private StudentVM viewModel;
        public UpdateStudentWindow(UpdateStudentVM viewModel )
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.CloseAction = () => Close(); 
        }

        private void UpdateModule_Click(object sender, RoutedEventArgs e)
        {
            //viewModel.LoadModulesFromDatabase();
            SelectModuleWindow selectmodule = new SelectModuleWindow();
            selectmodule.Show();
        }

       /* private void SaveUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            string StudentID = StudentIDUpdateTxt.Text;
            string StudentName = StudentNameUpdateTxt.Text;
            string age = StudentAgeUpdateTxt.Text;
            string StudentAddress = StudentAddressUpdateTxt.Text;
            string Semester = CurrentSemesterUpdateTxt.Text;

            Student newstudent = new Student
            {
               
                StudentID = StudentID,
                StudentName = StudentName,
                age = age,
                GPA = 0,
                StudentAddress = StudentAddress,
                Semester = Semester


            };

            viewModel.UpdateStudent(newstudent);
            MessageBox.Show("Details Updated succefully");
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
       

        }*/
    }
}
