using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFEventPractice2.ViewModel.Command;

namespace WPFEventPractice2.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Employee> ListOfEmployees { get; set; }

        public Employee SelectedEmployee { get; set; }

        public ICommand NewCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ShowCommand { get; set; }

        public MainWindowViewModel()
        {
            this.ShowCommand = new RelayCommand(this.ShowCommandExecute, this.ShowCommandsCanExecute);
            this.DeleteCommand = new RelayCommand(this.DeleteCommandExecute, this.DeleteCommandCanExecute);
            this.NewCommand = new RelayCommand(this.NewCommandExecute);

            this.ListOfEmployees = new ObservableCollection<Employee>();
        }

        private void NewCommandExecute(object obj)
        {
            this.ListOfEmployees.Add(new Employee());
        }

        private void DeleteCommandExecute(object obj)
        {
            this.ListOfEmployees.Remove(this.SelectedEmployee);
        }

        private bool DeleteCommandCanExecute(object obj)
        {
            if (this.SelectedEmployee == null)
            {
                return false;
            }
            return true;
        }

        private void ShowCommandExecute(object obj)
        {
            var collection = Employee.GetEmployeeList();

            foreach (var item in collection)
            {
                this.ListOfEmployees.Add(item);
            }
        }

        private bool ShowCommandsCanExecute(object obj)
        {
            if (this.ListOfEmployees.Count == 0)
            {
                return true;
            }
            return false;
        }

    }
}
