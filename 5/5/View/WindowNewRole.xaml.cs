using System;
using System.Windows;
using MyApp.Model;

namespace MyApp.View
{
    public partial class WindowNewRole : Window
    {
        public WindowNewRole()
        {
            InitializeComponent();
            RoleNameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoleNameTextBox.Text))
            {
                MessageBox.Show("Введите наименование должности!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                RoleNameTextBox.Focus();
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
} 