using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;

namespace ZzaDashboard.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customers;

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer SelectedCustomer { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                if (this.customers == value)
                    return;

                this.customers = value;
                this.OnPropertyChanged(nameof(this.Customers));
            }
        }

        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer>()
            {
                new Customer {FirstName = "Vlad", LastName = "Radchenko", Phone ="0346357357"},
                new Customer {FirstName = "Jeny", LastName="Filison", Phone="25248692"}
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
