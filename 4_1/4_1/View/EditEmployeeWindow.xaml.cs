using System;
using System.Collections.ObjectModel;
using System.Windows;
using _4_1.Model;

namespace _4_1.View
{
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow(PersonDPO person, ObservableCollection<Role> roles)
        {
            InitializeComponent();
            DataContext = person;
            Tag = roles; // Для передачи списка должностей в ComboBox
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PersonDPO person = DataContext as PersonDPO;
            if (person == null)
            {
                return;
            }
            
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                MessageBox.Show("Пожалуйста, введите имя", "Предупреждение");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                MessageBox.Show("Пожалуйста, введите фамилию", "Предупреждение");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(person.Role))
            {
                MessageBox.Show("Пожалуйста, выберите должность", "Предупреждение");
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