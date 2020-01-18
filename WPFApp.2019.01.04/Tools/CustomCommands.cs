using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp._2019._01._04.Views;

namespace WPFApp._2019._01._04.Tools
{
    public class CustomCommands
    {
        public static RoutedUICommand NewAuthor { get; set; }

        public static RoutedUICommand NewBook { get; set; }

        public static RoutedUICommand EditAuthor { get; set; }

        public static RoutedUICommand EditBook { get; set; }

        public static RoutedUICommand DeleteAuthor { get; set; }

        public static RoutedUICommand DeleteBook { get; set; }

        public static RoutedUICommand OkAuthor { get; set; }

        public static RoutedUICommand OkBook { get; set; }

        static CustomCommands()
        {
            CustomCommands.EditAuthor = new RoutedUICommand(nameof(EditAuthor), nameof(EditAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.EditBook = new RoutedUICommand(nameof(EditBook), nameof(EditBook), typeof(MainWindow), new InputGestureCollection());

            CustomCommands.NewAuthor = new RoutedUICommand(nameof(NewAuthor), nameof(NewAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.NewBook = new RoutedUICommand(nameof(NewBook), nameof(NewBook), typeof(MainWindow), new InputGestureCollection());

            CustomCommands.DeleteAuthor = new RoutedUICommand(nameof(DeleteAuthor), nameof(DeleteAuthor), typeof(MainWindow), new InputGestureCollection());
            CustomCommands.DeleteBook = new RoutedUICommand(nameof(DeleteBook), nameof(DeleteBook), typeof(MainWindow), new InputGestureCollection());

            CustomCommands.OkAuthor = new RoutedUICommand(nameof(OkAuthor), nameof(OkAuthor), typeof(AuthorInfoWindow), new InputGestureCollection());
            CustomCommands.OkBook = new RoutedUICommand(nameof(OkBook), nameof(OkBook), typeof(BookInfoWindow), new InputGestureCollection());
        }
    }
}
