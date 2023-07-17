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
        private UserDashboardVM viewModel;


        public UserDashboard()
        {
            InitializeComponent();
            viewModel = new UserDashboardVM();
            DataContext = viewModel;
            
        }

        private void Create_student_Click(object sender, RoutedEventArgs e)
        {
            CreateStudentWindow CreateStudent = new CreateStudentWindow();
            CreateStudent.Show();
        }

        private void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
