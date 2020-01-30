using SimpleZzaDashboard.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace SimpleZzaDashboard.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private ICustomersRepository repository;

        public ICommand GetCommand { get; set; }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.GetCommand = new RelayCommand(this.GetCommandExecute, this.GetCommandCanExecute);
            this.repository = new CustomersRepository();
            this.Customers = new ObservableCollection<Customer>();
        }

        private  void GetCommandExecute(object obj)
        {
            var customerCollection = this.repository.GetCustomersAsync().Result;

            foreach (var item in customerCollection)
            {
                this.Customers.Add(item);
            }
        }

        private bool GetCommandCanExecute(object obj)
        {
            return true;
        }
    }
}
