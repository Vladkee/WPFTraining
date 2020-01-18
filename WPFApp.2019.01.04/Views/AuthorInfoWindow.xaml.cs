using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFApp._2019._01._04.Model;

namespace WPFApp._2019._01._04.Views
{
    /// <summary>
    /// Interaction logic for AuthorInfoWindow.xaml
    /// </summary>
    public partial class AuthorInfoWindow : Window
    {
        private Author authorCashed;

        private Author authorOld;

        public AuthorInfoWindow(Author author)
        {
            InitializeComponent();

            this.authorCashed = new Author();
            this.DataContext = this.authorCashed;
            this.authorOld = author;

            this.authorCashed.FirstName = author.FirstName;
            this.authorCashed.LastName = author.LastName;
            this.authorCashed.BirthDate = author.BirthDate;
            this.authorCashed.Country = author.Country;
            this.authorCashed.Language = author.Language;
            this.authorCashed.PlaceOfBirth = author.PlaceOfBirth;
            this.authorCashed.IsNew = author.IsNew;
        }

        private void CancelCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OkAuthorCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();

            this.authorOld.FirstName = this.authorCashed.FirstName;
            this.authorOld.LastName = this.authorCashed.LastName;
            this.authorOld.BirthDate = this.authorCashed.BirthDate;
            this.authorOld.Country = this.authorCashed.Country;
            this.authorOld.Language = this.authorCashed.Language;
            this.authorOld.PlaceOfBirth = this.authorCashed.PlaceOfBirth;
            this.authorOld.IsNew = this.authorCashed.IsNew;
            this.authorOld.Books = new ObservableCollection<Book>();
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
