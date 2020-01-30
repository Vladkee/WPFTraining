using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class CustomerEditViewModel
    {
        private ICustomersRepository Repository { get; set; }

        private Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICommand SaveCommand { get; set; }

        public CustomerEditViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.Repository = new CustomersRepository();

            this.CustomerId = new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618");

            this.GetCustomerFromDataBase();

            this.SaveCommand = new RelayCommand(this.SaveCommandExecute, this.SaveCommandCanExecute);
        }

        public void GetCustomerFromDataBase()
        {
            this.Customer = this.Repository.GetCustomerAsync(this.CustomerId).Result;
            //Customer= this.Repository.GetCustomerAsync(new Guid("11DA4696 - CEA3 - 4A6D - 8E83 - 013F1C479618")).Result;
        }

        public bool SaveCommandCanExecute(object obj)
        {
            if (!string.IsNullOrWhiteSpace(this.Customer.FirstName) || !string.IsNullOrWhiteSpace(this.Customer.LastName) || !string.IsNullOrWhiteSpace(this.Customer.Phone))
            {
                return true;
            }
            else
                return false;
        }

        public async void SaveCommandExecute(object obj)
        {
            await this.Repository.UpdateCustomerAsync(this.Customer);
        }
    }
}
