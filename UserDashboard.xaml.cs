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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    
    public partial class UserDashboard : Window
    {
        private StudentVM viewModel;
        private UserDashboardVM vm;
        public UserDashboard()
        {
            InitializeComponent();
            viewModel = new StudentVM();
            DataContext = viewModel;
        }

        private void Create_student_Click(object sender, RoutedEventArgs e)
        {
            CreateStudentWindow CreateStudent = new CreateStudentWindow();
            CreateStudent.Show();
        }

       /* private void Delete_student_Click(object sender, RoutedEventArgs e)
        {
            vm = new UserDashboardVM();
            viewModel.DeleteStudent(vm.SelectedStudent);

        }
       */
        private void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
