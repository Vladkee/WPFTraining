using Shop.DAL.Context;
using Shop.DAL.Model;
using Shop.DAL.Repository;
using ShopWPFCore.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ShopWPFCore.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;

        private Product selectedProduct;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteCommand { get; set; }

        public ICommand DefaultCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public IRepository<Product> Repos { get; }


        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (this.selectedProduct == value)
                    return;

                this.selectedProduct = value;
                this.OnPropertyChanged(nameof(this.SelectedProduct));
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                if (this.products == value)
                    return;

                this.products = value;
                this.OnPropertyChanged(nameof(this.Products));
            }
        }

        public MainWindowViewModel()
        {
            this.Repos = new GenericRepository<Product>();
            this.Products = new ObservableCollection<Product>(this.Repos.Get());

            //this.Products = new ObservableCollection<Product>()
            //{
            //    new Product("TV", "LG", "CX25167","Korea", "FullHD", "Black", 15000.00m, @"C:\Users\Admin\source\repos\PracticeWPF\PracticeWPF\bin\Debug\Pictures\TVImage.jpg"),
            //    new Product("Headphones", "AKG", "X351","Japan","Open-Back", "Gray", 500.00m, @"C:\Users\Admin\source\repos\PracticeWPF\PracticeWPF\bin\Debug\Pictures\HeadphonesImage.jpg"),
            //    new Product("Notebook", "Acer", "P44","China", "Laptop", "Blue", 20000.00m, @"C:\Users\Admin\source\repos\PracticeWPF\PracticeWPF\bin\Debug\Pictures\NotebookImage.jpg")
            //};

            this.DeleteCommand = new RelayCommand(this.DeleteCommandExecuted, this.CommandCanExecute);
            this.DefaultCommand = new RelayCommand(this.DefaultCommandExecuted, this.CommandCanExecute);
            this.AddCommand = new RelayCommand(this.AddCommandExecuted);
            this.SaveCommand = new RelayCommand(this.SaveCommandExecuted);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CommandCanExecute(object obj)
        {
            if (this.SelectedProduct != null)
            {
                return true;
            }
            else
                return false;
        }

        public void DeleteCommandExecuted(object obj)
        {
            this.Repos.Delete(this.SelectedProduct);
            this.Products.Remove(this.SelectedProduct);
        }

        public void AddCommandExecuted(object obj)
        {
            var newProduct = new Product("NewName", "NewBrend", "NewModel", "NewCountry", "NewType", "NewColor", 0.00m, "NewImage");
            this.Repos.Add(newProduct);
            this.Products.Add(newProduct);
            this.Repos.Save();
        }

        public void SaveCommandExecuted(object obj)
        {
            this.Repos.Save();
            MessageBox.Show("Changes have beed saved");
        }

        public void DefaultCommandExecuted(object obj)
        {
            this.SelectedProduct.Name = "DefaultName";
            this.SelectedProduct.Brend = "DefaultBrend";
            this.SelectedProduct.Model = "DefaultModel";
            this.SelectedProduct.Country = "DefaultCountry";
            this.SelectedProduct.Type = "DefaultType";
            this.SelectedProduct.Color = "DefaultColor";
            this.SelectedProduct.Price = 0.00m;
        }
    }
}
