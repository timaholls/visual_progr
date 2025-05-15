using System;
using System.Collections.ObjectModel;
using System.Windows;
using _4_1.Model;
using _4_1.ViewModel;

namespace _4_1.View
{
    public partial class EditEmployeeWindow : Window
    {
        private PersonDPO _employee;
        private ObservableCollection<Role> _roles;
        private bool _isNew;
        
        public PersonDPO Employee => _employee;
        
        // Constructor for editing existing employee
        public EditEmployeeWindow(PersonDPO employee, ObservableCollection<Role> roles)
        {
            InitializeComponent();
            
            _employee = new PersonDPO(
                employee.Id,
                employee.Role,
                employee.FirstName, 
                employee.LastName, 
                employee.Birthday);
            
            _roles = roles;
            _isNew = false;
            
            LoadData();
        }
        
        // Constructor for adding new employee
        public EditEmployeeWindow(ObservableCollection<Role> roles, int nextId)
        {
            InitializeComponent();
            
            _employee = new PersonDPO(
                nextId,
                "",
                "", 
                "", 
                DateTime.Now);
            
            _roles = roles;
            _isNew = true;
            
            LoadData();
        }
        
        private void LoadData()
        {
            txtFirstName.Text = _employee.FirstName;
            txtLastName.Text = _employee.LastName;
            dpBirthday.SelectedDate = _employee.Birthday;
            
            cmbRole.ItemsSource = _roles;
            
            // Find the role that matches the employee's role name
            foreach (var role in _roles)
            {
                if (role.NameRole == _employee.Role)
                {
                    cmbRole.SelectedItem = role;
                    break;
                }
            }
            
            // If it's a new employee and no role was selected, select the first one
            if (_isNew && cmbRole.SelectedItem == null && _roles.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя", "Предупреждение");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию", "Предупреждение");
                return;
            }
            
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите должность", "Предупреждение");
                return;
            }
            
            if (dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите дату рождения", "Предупреждение");
                return;
            }
            
            // Update employee data
            _employee.FirstName = txtFirstName.Text;
            _employee.LastName = txtLastName.Text;
            _employee.Role = ((Role)cmbRole.SelectedItem).NameRole;
            _employee.Birthday = dpBirthday.SelectedDate.Value;
            
            DialogResult = true;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
} 