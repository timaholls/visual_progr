using System;
using System.Collections.ObjectModel;
using System.Windows;
using _4_1.Model;
using _4_1.ViewModel;

namespace _4_1.View
{
    /// <summary>
    /// Interaction logic for WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        private PersonViewModel vmPerson;
        
        public WindowEmployee()
        {
            InitializeComponent();
            vmPerson = new PersonViewModel();
            lvEmployee.ItemsSource = vmPerson.ListPerson;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditEmployeeWindow(vmPerson.Roles, vmPerson.GetNextPersonId());
            dialog.Owner = this;
            
            if (dialog.ShowDialog() == true)
            {
                vmPerson.AddPerson(dialog.Employee);
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem != null)
            {
                var selectedEmployee = (PersonDPO)lvEmployee.SelectedItem;
                var dialog = new EditEmployeeWindow(selectedEmployee, vmPerson.Roles);
                dialog.Owner = this;
                
                if (dialog.ShowDialog() == true)
                {
                    vmPerson.UpdatePerson(dialog.Employee);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования", "Предупреждение");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem != null)
            {
                var selectedEmployee = (PersonDPO)lvEmployee.SelectedItem;
                
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить сотрудника {selectedEmployee.LastName} {selectedEmployee.FirstName}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    vmPerson.DeletePerson(selectedEmployee.Id);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления", "Предупреждение");
            }
        }
    }
} 