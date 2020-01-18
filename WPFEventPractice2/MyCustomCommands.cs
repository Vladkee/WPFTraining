using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFEventPractice2
{
    public static class MyCustomCommands
    {
        public static RoutedUICommand Show { get; set; }

        public static RoutedUICommand Add { get; set; }

        static MyCustomCommands()
        {
            MyCustomCommands.Show = new RoutedUICommand(nameof(Show), nameof(Show), typeof(MainWindow), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Control) });

            MyCustomCommands.Add = new RoutedUICommand(nameof(Add), nameof(Add), typeof(AskWindow), new InputGestureCollection { new KeyGesture(Key.Enter) });
        }
    }
}
