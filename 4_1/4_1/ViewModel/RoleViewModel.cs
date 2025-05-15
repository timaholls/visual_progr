using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using _4_1.Helper;
using _4_1.Model;
using _4_1.View;

namespace _4_1.ViewModel
{
    public class RoleViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Role> _listRole = new ObservableCollection<Role>();
        private Role _selectedRole;
        
        // Команды
        private RelayCommand _addRole;
        private RelayCommand _editRole;
        private RelayCommand _deleteRole;
        
        public RelayCommand AddRole
        {
            get
            {
                return _addRole ?? (_addRole = new RelayCommand(obj =>
                {
                    // Формирование кода новой должности
                    int roleId = GetNextRoleId();
                    Role role = new Role(roleId, "");
                    
                    EditRoleWindow wnRole = new EditRoleWindow(role);
                    if (wnRole.ShowDialog() == true)
                    {
                        ListRole.Add(role);
                    }
                }));
            }
        }

        public RelayCommand EditRole
        {
            get
            {
                return _editRole ?? (_editRole = new RelayCommand(obj =>
                {
                    Role role = SelectedRole;
                    // Создаем копию для редактирования
                    Role tempRole = new Role(role.Id, role.NameRole);
                    
                    EditRoleWindow wnRole = new EditRoleWindow(tempRole);
                    if (wnRole.ShowDialog() == true)
                    {
                        role.NameRole = tempRole.NameRole;
                    }
                }, (obj) => SelectedRole != null));
            }
        }

        public RelayCommand DeleteRole
        {
            get
            {
                return _deleteRole ?? (_deleteRole = new RelayCommand(obj =>
                {
                    Role role = SelectedRole;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " + role.NameRole,
                        "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    
                    if (result == MessageBoxResult.OK)
                    {
                        ListRole.Remove(role);
                    }
                }, (obj) => SelectedRole != null));
            }
        }
        
        public ObservableCollection<Role> ListRole
        {
            get { return _listRole; }
            set { SetProperty(ref _listRole, value); }
        }
        
        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                SetProperty(ref _selectedRole, value);
                OnPropertyChanged("SelectedRole");
            }
        }

        public RoleViewModel()
        {
            // Add sample roles
            ListRole.Add(new Role(1, "Директор"));
            ListRole.Add(new Role(2, "Бухгалтер"));
            ListRole.Add(new Role(3, "Менеджер"));
        }
        
        public int GetNextRoleId()
        {
            return ListRole.Count > 0 ? ListRole.Max(r => r.Id) + 1 : 1;
        }
    }
} 