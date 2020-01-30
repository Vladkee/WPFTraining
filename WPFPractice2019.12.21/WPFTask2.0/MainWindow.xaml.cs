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

namespace WPFTask2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new Handler();

            //this.Resources.Add("FirstName1", "Petro");
            //this.Resources.Add("LasttName1", "Pukin");
            //this.Resources.Add("MasterDegree1", false);

            //this.txbFirstName.Text = (string)this.TryFindResource("FirstName1");
            //this.txbLastName.Text = (string)this.TryFindResource("LasttName1");
            //this.ckbMasterDegree.IsChecked = (bool)this.TryFindResource("MasterDegree1");
        }
    }
}
