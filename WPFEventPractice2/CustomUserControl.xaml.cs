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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFEventPractice2
{
    /// <summary>
    /// Interaction logic for CustomUserControl.xaml
    /// </summary>
    public partial class CustomUserControl : UserControl
    {
        MainWindow instance;

        public CustomUserControl()
        {
            InitializeComponent();

            instance = new MainWindow();

            instance.MyDataGrid.ItemsSource = instance.ListOfEmployees;
        }

        private void AddCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            instance.ListOfEmployees.Add(new Employee(Employee.Counter++, this.NameTextBox.Text, this.DepartmentTextBox.Text, this.HiredDateTexkBox.Text, false ));
        }

        private void AddCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
