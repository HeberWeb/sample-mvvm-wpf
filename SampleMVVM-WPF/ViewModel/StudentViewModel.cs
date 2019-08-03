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
        public MyICommand DeleteCommand { get; set; }

        public StudentViewModel()
        {
            LoadStudents();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public void LoadStudents()
        {
            Students.Add(new Student { FirstName = "Diego", LastName = "Rondão" });
            Students.Add(new Student { FirstName = "Diogo", LastName = "Rondão" });
            Students.Add(new Student { FirstName = "João", LastName = "Victor" });
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }
    }
}
