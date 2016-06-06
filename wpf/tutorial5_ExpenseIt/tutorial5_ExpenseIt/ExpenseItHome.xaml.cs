﻿using System;
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

namespace tutorial5_ExpenseIt
{
    /// <summary>
    /// ExpenseItHome.xaml の相互作用ロジック
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        private void View_Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReportPage erp = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(erp);
        }
    }
}
