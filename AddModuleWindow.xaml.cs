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
    /// Interaction logic for AddModuleWindow.xaml
    /// </summary>
    public partial class AddModuleWindow : Window
    {
        private AddModuleVM ModuleVM;
        public AddModuleWindow()
        {
            InitializeComponent();
            ModuleVM = new AddModuleVM();
        }

        private void AddModuleButton_Click(object sender, RoutedEventArgs e)
        {
            string modulecode = ModuleCodeTxt.Text;
            string modulename = ModuleNameTxt.Text;
            string department = DepartmentTxt.Text;
            string semester = SemsterTxt.Text;
            int credits = int.Parse(CreditTxt.Text);

            Module newModule = new Module
            {
                ModuleName = modulecode,
                ModuleCode = modulecode,
                Department = department,
                Semester = semester,
                Credits = credits

            };
            ModuleVM.AddModule(newModule);

            MessageBox.Show("Module added successfully!");

            Close();


        }

      
    }
}
