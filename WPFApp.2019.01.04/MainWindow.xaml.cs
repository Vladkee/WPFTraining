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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp._2019._01._04.Model;
using WPFApp._2019._01._04.Tools;
using WPFApp._2019._01._04.Views;

namespace WPFApp._2019._01._04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> ListOfAuthors{ get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.ListOfAuthors = ObjectGenerator.GetListOfAuthors();

            this.myListView.ItemsSource = ListOfAuthors;
        }

        private void NewAuthorCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var newAuthor = new Author();
            var window = new AuthorInfoWindow(newAuthor);

            var result = window.ShowDialog();

            if (!result.Value)
            {
                return;
            }
            else
            {
                newAuthor.Save();
                this.ListOfAuthors.Add(newAuthor);
            }
        }

        private void NewBookCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var newBook = new Book();
            var window = new BookInfoWindow(newBook);

            var result = window.ShowDialog();

            if (!result.Value)
            {
                return;
            }
            else
            {
                newBook.Save();
                this.ListOfAuthors[this.myListView.SelectedIndex].Books.Add(newBook);
            }
        }

        private void NewCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteAuthorCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedAuthor = this.myListView.SelectedItem as Author;
            this.ListOfAuthors.Remove(selectedAuthor);
        }

        private void DeleteBookCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedBook = this.myDataGrid.SelectedItem as Book;
            this.ListOfAuthors[myListView.SelectedIndex].Books.Remove(selectedBook);
        }

        private void ChangeAuthorCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.myListView.SelectedItem == null)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void ChangeBookCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.myDataGrid.SelectedItem == null)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }


        private void EditAuthorCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedAuthor = this.myListView.SelectedItem as Author;

            var window = new AuthorInfoWindow(selectedAuthor);

            var result = window.ShowDialog();
            
            if (result.Value)
            {
                this.myListView.Items.Refresh();
            }
            else
            {
                return;
            }
        }

        private void EditBookCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedBook = this.myDataGrid.SelectedItem as Book;

            var window  = new BookInfoWindow(selectedBook);

            var result = window.ShowDialog();

            if (result.Value)
            {
                this.myDataGrid.Items.Refresh();
            }
            else
            {
                return;
            }
        }
    }
}
