using System;
using System.Windows;
using _4_1.View;

namespace _4_1.View
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

        private void Employee_OnClick(object sender, RoutedEventArgs e)
        {
            WindowEmployee windowEmployee = new WindowEmployee();
            windowEmployee.ShowDialog();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole windowRole = new WindowRole();
            windowRole.ShowDialog();
        }
    }
} 