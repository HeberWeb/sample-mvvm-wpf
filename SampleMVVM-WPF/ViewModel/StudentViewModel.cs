using SampleMVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVM_WPF.ViewModel
{
    class StudentViewModel
    {
        public StudentViewModel()
        {
            LoadStudents();
        }
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public void LoadStudents()
        {
            Students.Add(new Student { FirstName = "Diego", LastName = "Rondão" });
            Students.Add(new Student { FirstName = "Diogo", LastName = "Rondão" });
            Students.Add(new Student { FirstName = "João", LastName = "Victor" });
        }
    }
}
