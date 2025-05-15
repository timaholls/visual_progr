using System;
using System.Windows;

namespace _3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTask1_1(object sender, RoutedEventArgs e)
        {
            Task1_1 task = new Task1_1();
            task.Show();
        }

        private void OpenTask1_2(object sender, RoutedEventArgs e)
        {
            Task1_2 task = new Task1_2();
            task.Show();
        }

        private void OpenTask2_1(object sender, RoutedEventArgs e)
        {
            Task2_1 task = new Task2_1();
            task.Show();
        }
    }
} 