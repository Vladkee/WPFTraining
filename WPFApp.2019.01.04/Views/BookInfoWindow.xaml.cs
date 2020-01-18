using System;
using System.Collections.Generic;
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
    /// Interaction logic for BookInfoWindow.xaml
    /// </summary>
    public partial class BookInfoWindow : Window
    {
        private Book bookCashed;

        private Book bookOld;

        public BookInfoWindow(Book book)
        {
            InitializeComponent();

            this.bookCashed = new Book();
            this.DataContext = this.bookCashed;
            this.bookOld = book;

            this.bookCashed.Title = book.Title;
            this.bookCashed.Date = book.Date;
            this.bookCashed.Cost = book.Cost;
            this.bookCashed.IsNew = book.IsNew;
        }

        private void CancelCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OkBookCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();

            this.bookOld.Title = this.bookCashed.Title;
            this.bookOld.Date = this.bookCashed.Date;
            this.bookOld.Cost = this.bookCashed.Cost;
            this.bookOld.IsNew = this.bookCashed.IsNew;

        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
