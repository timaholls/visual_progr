using System;
using System.Collections.ObjectModel;
using System.Windows;
using _4_1.Model;
using _4_1.ViewModel;

namespace _4_1.View
{
    /// <summary>
    /// Interaction logic for WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        private RoleViewModel vmRole;
        
        public WindowRole()
        {
            InitializeComponent();
            vmRole = new RoleViewModel();
            lvRole.ItemsSource = vmRole.ListRole;
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditRoleWindow(vmRole.GetNextRoleId());
            dialog.Owner = this;
            
            if (dialog.ShowDialog() == true)
            {
                vmRole.AddRole(dialog.Role);
            }
        }

        private void EditRole_Click(object sender, RoutedEventArgs e)
        {
            if (lvRole.SelectedItem != null)
            {
                var selectedRole = (Role)lvRole.SelectedItem;
                var dialog = new EditRoleWindow(selectedRole);
                dialog.Owner = this;
                
                if (dialog.ShowDialog() == true)
                {
                    vmRole.UpdateRole(dialog.Role);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите должность для редактирования", "Предупреждение");
            }
        }

        private void DeleteRole_Click(object sender, RoutedEventArgs e)
        {
            if (lvRole.SelectedItem != null)
            {
                var selectedRole = (Role)lvRole.SelectedItem;
                
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить должность '{selectedRole.NameRole}'?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    vmRole.DeleteRole(selectedRole.Id);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите должность для удаления", "Предупреждение");
            }
        }
    }
} 