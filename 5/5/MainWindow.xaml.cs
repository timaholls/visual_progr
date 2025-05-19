using System;
using System.Windows;
using System.Windows.Controls;
using MyApp.Model;
using MyApp.ViewModel;
using MyApp.View;

namespace MyApp
{
    public partial class MainWindow : Window
    {
        private PersonViewModel personViewModel;
        private RoleViewModel roleViewModel;
        private Person selectedPerson;
        private Role selectedRole;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            personViewModel = new PersonViewModel();
            roleViewModel = new RoleViewModel();

            PersonGrid.ItemsSource = personViewModel.ListPerson;
            RoleGrid.ItemsSource = roleViewModel.ListRole;
        }

        // Person methods
        private void PersonGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPerson = (Person)PersonGrid.SelectedItem;
            EditPersonButton.IsEnabled = DeletePersonButton.IsEnabled = (selectedPerson != null);
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson wnPerson = new WindowNewPerson();
            wnPerson.DataContext = new Person
            {
                Birthday = DateTime.Now
            };
            wnPerson.Title = "Новый сотрудник";
            wnPerson.Owner = this;

            if (wnPerson.ShowDialog() == true)
            {
                Person newPerson = (Person)wnPerson.DataContext;
                personViewModel.AddPerson(newPerson);
            }
        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPerson == null) return;

            WindowNewPerson wnPerson = new WindowNewPerson();
            wnPerson.DataContext = selectedPerson;
            wnPerson.Title = "Редактирование данных сотрудника";
            wnPerson.Owner = this;

            if (wnPerson.ShowDialog() == true)
            {
                Person editPerson = (Person)wnPerson.DataContext;
                personViewModel.EditPerson(editPerson);
            }
        }

        private void DeletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPerson == null) return;
            personViewModel.DeletePerson(selectedPerson);
        }

        // Role methods
        private void RoleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRole = (Role)RoleGrid.SelectedItem;
            EditRoleButton.IsEnabled = DeleteRoleButton.IsEnabled = (selectedRole != null);
        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnRole = new WindowNewRole();
            wnRole.DataContext = new Role();
            wnRole.Title = "Новая должность";
            wnRole.Owner = this;

            if (wnRole.ShowDialog() == true)
            {
                Role newRole = (Role)wnRole.DataContext;
                roleViewModel.AddRole(newRole);
            }
        }

        private void EditRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRole == null) return;

            WindowNewRole wnRole = new WindowNewRole();
            wnRole.DataContext = selectedRole;
            wnRole.Title = "Редактирование должности";
            wnRole.Owner = this;

            if (wnRole.ShowDialog() == true)
            {
                Role editRole = (Role)wnRole.DataContext;
                roleViewModel.EditRole(editRole);
            }
        }

        private void DeleteRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRole == null) return;
            roleViewModel.DeleteRole(selectedRole);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 