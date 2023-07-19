using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public partial class ViewStudentVM :ObservableObject
    {
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
    }
}
