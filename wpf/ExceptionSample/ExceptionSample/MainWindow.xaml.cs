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

namespace ExceptionSample
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

        //Button(close)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //Button(Exception open)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException("まだ実装していません");
        }

        //Button(Exception close)
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            app.DispatcherUnhandledException -= app.Application_DispatcherUnhandledException;

        }
    }
}
