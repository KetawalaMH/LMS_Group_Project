using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Group_Project
{
    public partial class SelectModulesVM :ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Module> modules;
        



      
       private void LoadModules()
        {
            // Retrieve the students from the student table in the database and populate the Students collection

            Modules = new ObservableCollection<Module>(GetModulesFromDatabase());
        }

        private static IEnumerable<Module> GetModulesFromDatabase()
        {
            // Retrieve the student data from the student table in the database
            // and return the result as a collection of Student objects


            using (var dbContext = new UserDataContext())
            {
                return dbContext.Modules.ToList();
            }
        }
        public SelectModulesVM()
        {
            LoadModules();
        }
        


    }
}
