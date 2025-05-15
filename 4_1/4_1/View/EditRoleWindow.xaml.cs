using System;
using System.Windows;
using _4_1.Model;

namespace _4_1.View
{
    public partial class EditRoleWindow : Window
    {
        public EditRoleWindow(Role role)
        {
            InitializeComponent();
            DataContext = role;
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Role role = DataContext as Role;
            if (role == null)
            {
                return;
            }
            
            if (string.IsNullOrWhiteSpace(role.NameRole))
            {
                MessageBox.Show("Пожалуйста, введите наименование должности", "Предупреждение");
                return;
            }
            
            DialogResult = true;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
} 