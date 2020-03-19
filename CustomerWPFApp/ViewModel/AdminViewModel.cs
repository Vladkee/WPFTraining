using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;
using Model.Entity;
using Model.Extension;
using Model.Service;

namespace ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        private ShopService shopService;

        private ObservableCollection<Customer> customers;

        private Customer selectedCustomer;

        private Order selectedOrder;

        public AdminViewModel()
        {
            this.shopService = new ShopService();
            this.Customers = this.shopService.GetCustomers().ToObservableCollection();
        }

        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set
            {
                this.customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return this.selectedCustomer; }
            set
            {
                this.selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public Order SelectedOrder
        {
            get { return this.selectedOrder; }
            set
            {
                this.selectedOrder = value;
                OnPropertyChanged();
            }
        }
    }
}