using System;
using System.ComponentModel;

namespace Shop.DAL.Model
{
    public class Product : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;

        private string brend;

        private string model;

        private string country;

        private string type;

        private string color;

        private decimal price;

        private string image;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        public string Brend
        {
            get
            {
                return this.brend;
            }
            set
            {
                if (this.brend == value)
                    return;

                this.brend = value;
                this.OnPropertyChanged(nameof(this.Brend));
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country == value)
                    return;

                this.country = value;
                this.OnPropertyChanged(nameof(this.Country));
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type == value)
                    return;

                this.type = value;
                this.OnPropertyChanged(nameof(this.Type));
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (this.color == value)
                    return;

                this.color = value;
                this.OnPropertyChanged(nameof(this.Color));
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price == value)
                    return;

                this.price = value;
                this.OnPropertyChanged(nameof(this.Price));
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                if (this.image == value)
                    return;

                this.image = value;
                this.OnPropertyChanged(nameof(this.Image));
            }
        }

        public Product(string name, string brend, string model, string country, string type, string color, decimal price, string image)
        {
            this.Name = name;
            this.Brend = brend;
            this.Model = model;
            this.Country = country;
            this.Type = type;
            this.Color = color;
            this.Price = price;
            this.Image = image;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
