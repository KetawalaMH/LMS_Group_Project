using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for LoginWIndow.xaml
    /// </summary>
    public partial class LoginWIndow : Window
    {
        private UserVM UserviewModel;
        private AdminVM AdminviewModel;
        public LoginWIndow()
        {
            InitializeComponent();
            UserviewModel = new UserVM();
            AdminviewModel = new AdminVM();
        }

        private void Submit_Click (object sender, RoutedEventArgs e)
        {
            string username = UserNameText.Text;
            string password = PasswordText.Text;

            bool isUserAuthenticated = UserviewModel.AuthenticateUser(username, password);
            bool isAdminAuthenticated = AdminviewModel.AuthenticateAdmin(username, password);

            if (isUserAuthenticated)
            {
                UserDashboard userDash = new UserDashboard();
                userDash.Show();
                // Navigate to the main application window or perform any other necessary actions
            }
            else if (isAdminAuthenticated) 
            {
                AdminDashboard AdminDash = new AdminDashboard();
                AdminDash.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }


        }


    }
}
