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
using System.IO;
using System.Xml;
using System.Windows.Markup;

namespace XamlTraining
{
    /// <summary>
    /// Home.xaml の相互作用ロジック
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var sr = new StreamReader("UserControl1.xaml"))
            {
                var xml = XmlReader.Create(sr.BaseStream);
                var ctrls = XamlReader.Load(xml) as UIElement;
                var item = new TabItem()
                {
                    Header = "Loaded UserControl",
                    Content = ctrls
                };
                tabControl1.Items.Add(item);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2();
            this.NavigationService.Navigate(p2);
        }
    }
}
