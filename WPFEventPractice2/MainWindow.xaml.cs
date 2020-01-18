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

namespace WPFEventPractice2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> ListOfEmployees { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.ListOfEmployees = Employee.GetEmployeeList();

            this.MyDataGrid.ItemsSource = this.ListOfEmployees;

            Employee.Counter = this.ListOfEmployees.Count + 1;
        }

        private void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            new AskWindow() { DataContext = this.MyDataGrid }.Show();
        }

        private void ShowCommandExecuted (object sender, ExecutedRoutedEventArgs e)
        {
            new InformationWindow() { DataContext = this.MyDataGrid.SelectedItem }.Show();
        }

        private void DeleteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedDataGridItem = this.MyDataGrid.SelectedItem as Employee;
            this.ListOfEmployees.Remove(selectedDataGridItem);
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
