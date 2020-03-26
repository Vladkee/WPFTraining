using Model.Entity;
using Model.Extension;
using Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ShopService shopService;

        private ObservableCollection<Product> products;

        private Product selectedProduct;

        public CustomerViewModel()
        {
            this.shopService = new ShopService();
            this.Products = this.shopService.GetProducts().ToObservableCollection();
        }

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set
            {
                this.products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get { return this.selectedProduct; }
            set
            {
                this.selectedProduct = value;
                OnPropertyChanged();
            }
        }
    }
}