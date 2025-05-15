using System;
using System.Windows;
using _4_1.Model;

namespace _4_1.View
{
    public partial class EditRoleWindow : Window
    {
        private Role _role;
        
        public Role Role => _role;
        
        // Constructor for editing existing role
        public EditRoleWindow(Role role)
        {
            InitializeComponent();
            
            _role = new Role(role.Id, role.NameRole);
            LoadData();
        }
        
        // Constructor for adding new role
        public EditRoleWindow(int nextId)
        {
            InitializeComponent();
            
            _role = new Role(nextId, "");
            LoadData();
        }
        
        private void LoadData()
        {
            txtRoleName.Text = _role.NameRole;
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Пожалуйста, введите наименование должности", "Предупреждение");
                return;
            }
            
            // Update role data
            _role.NameRole = txtRoleName.Text;
            
            DialogResult = true;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
} 