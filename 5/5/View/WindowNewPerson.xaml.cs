using System;
using System.Windows;
using MyApp.Model;
using MyApp.ViewModel;

namespace MyApp.View
{
    public partial class WindowNewPerson : Window
    {
        private RoleViewModel roleViewModel;

        public WindowNewPerson()
        {
            InitializeComponent();
            roleViewModel = new RoleViewModel();
            RoleComboBox.ItemsSource = roleViewModel.ListRole;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = (Person)DataContext;

            if (RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                RoleComboBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                MessageBox.Show("Введите фамилию!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                MessageBox.Show("Введите имя!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
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