using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp._2019._01._04.Model;

namespace WPFApp._2019._01._04.Tools
{
    public class ObjectGenerator
    {
        public static ObservableCollection<Author> GetListOfAuthors()
        {
            var listOfAuthors = new ObservableCollection<Author>
            {
                new Author("Peter", "Grifin", new DateTime(1973,05,02), Countries.USA, Languages.English, "Florida")
                {
                    IsNew = false,
                    Books = new ObservableCollection<Book>()
                    {
                        new Book(1, "Peter Pen", new DateTime(1982, 11, 23), 9.99m) { IsNew = false }
                    }
                },
                new Author("Frank", "Brown", new DateTime(1978, 03, 20), Countries.Germany, Languages.German, "Berlin")
                {
                    IsNew = false,
                    Books = new ObservableCollection<Book>()
                    {
                        new Book(2, "Island", new DateTime(2000, 01, 12), 7.99m) { IsNew = false }
                    }
                },
                new Author("Askold", "Grud", new DateTime(1953, 10, 13), Countries.Sweden, Languages.Swedish, "Sala")
                {
                    IsNew = false,
                    Books = new ObservableCollection<Book>()
                    {
                        new Book(3, "Bones", new DateTime(2012, 03, 20), 3.99m) { IsNew = false }
                    }
                }
            };

            return listOfAuthors;
        }
    }
}
