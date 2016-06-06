using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace tutorial6_DataGridSQLExample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {





        public MainWindow()
        {
            InitializeComponent();
        }




        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }





        public void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("======================");
            Console.WriteLine(textBox1.Text);
            Console.WriteLine("======================");

            ViewModel vm = new ViewModel();
            dataGrid1.ItemsSource = vm.setQuery(textBox1.Text);
        }

    }
}
