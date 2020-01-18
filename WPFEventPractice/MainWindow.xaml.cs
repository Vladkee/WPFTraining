using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFEventPractice1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseEnter: source {e.Source} sender {sender}");
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Click: source {e.Source} sender {sender}");

            if (e.Source is CheckBox)
            {
                return;
            }

            for (int i = 1; i < 4; i++)
            {
                Button btn = new Button() { Content = $"Button {i}" };
                btn.Margin = new Thickness(5);
                MyStackPanel.Children.Add(btn);
                btn.AddHandler(Button.ClickEvent, new RoutedEventHandler(ChangeColorButton));
            }
        }

        private void MyBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"MouseDown: source {e.Source} sender {sender}");
        }

        private void ChangeColorButton(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Background = Brushes.Green;

            e.Handled = true;
        }

        private void CheckBoxBtn_Clicked(object sender, RoutedEventArgs e)
        {
            if (this.CheckBoxBtn.IsChecked == false)
            {
                this.EllipseFigure.Fill = Brushes.White;
                this.EllipseFigure.Stroke = Brushes.Black;
            }
            else
            {
                this.EllipseFigure.Fill = Brushes.Green;
            }
        }
    }
}
