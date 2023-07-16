using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group_Project
{
    public partial class CrewateStudentVM :ObservableObject
    {
        [ObservableProperty]
        public string studentid;


        [ObservableProperty]
        public string studentname;
        [ObservableProperty]
        public string address;
        [ObservableProperty]
        public string age;

        [ObservableProperty]
        public string semester;

        [ObservableProperty]
        public double gpa;



        //To change the tile



        [ObservableProperty]
        public string title;

        



        public CrewateStudentVM(Student u)
        {
            Student = u;

            studentid = Student.StudentID;
            studentname = Student.StudentName;
            gpa = Student.GPA;
            address = Student.StudentAddress;
            semester = Semester;
           

        }
        public CrewateStudentVM()
        {

        }


        





        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Student == null)
            {

                Student = new Student()
                {
                    StudentID = studentid,
                    StudentName = studentname,
                    StudentAddress = address,
                    Semester = semester,

                    GPA = gpa

                };


            }
            else
            {

                Student.StudentID = Studentid;
                Student.StudentName = studentname;
                Student.GPA = gpa;
                Student.StudentAddress = address;
                Student.age = age;



            }

            if (Student.StudentID != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }
    }
}
