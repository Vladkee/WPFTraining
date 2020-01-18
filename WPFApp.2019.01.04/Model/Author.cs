using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp._2019._01._04.Tools;

namespace WPFApp._2019._01._04.Model
{
    public class Author : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Countries Country { get; set; }

        public Languages Language { get; set; }

        public string PlaceOfBirth { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        public Author(string firstName, string lastName, DateTime birthDate, Countries country, Languages language, string placeOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Country = country;
            this.Language = language;
            this.PlaceOfBirth = placeOfBirth;
        }

        public Author()
        {

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
