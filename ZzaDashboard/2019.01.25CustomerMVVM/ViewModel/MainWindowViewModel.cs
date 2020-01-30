using _2019._01._25CustomerMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019._01._25CustomerMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer>()
            {
                new Customer {FirstName = "Vlad", LastName = "Radchenko", City ="Kharkiv"},
                new Customer {FirstName = "Jeny", LastName="Filison", City="Washington"}
            };
        }
    }
}
