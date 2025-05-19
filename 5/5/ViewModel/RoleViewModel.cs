using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MyApp.Model;

namespace MyApp.ViewModel
{
    public class RoleViewModel
    {
        private ObservableCollection<Role> _listRole;
        private CompanyEntities context;

        public RoleViewModel()
        {
            _listRole = new ObservableCollection<Role>();
            context = new CompanyEntities();
            _listRole = GetRoles();
        }

        public ObservableCollection<Role> ListRole 
        { 
            get { return _listRole; }
            private set { _listRole = value; }
        }

        private ObservableCollection<Role> GetRoles()
        {
            ObservableCollection<Role> roles = new ObservableCollection<Role>();
            using (var context = new CompanyEntities())
            {
                var query = from role in context.Roles
                            orderby role.NameRole
                            select role;

                if (query.Count() != 0)
                {
                    foreach (var r in query)
                    {
                        roles.Add(r);
                    }
                }
                return roles;
            }
        }

        public void AddRole(Role newRole)
        {
            context.Roles.Add(newRole);
            context.SaveChanges();
            _listRole.Clear();
            var roles = GetRoles();
            foreach (var role in roles)
            {
                _listRole.Add(role);
            }
        }

        public void EditRole(Role editRole)
        {
            Role role = context.Roles.Find(editRole.Id);
            if (role.NameRole != editRole.NameRole)
                role.NameRole = editRole.NameRole.Trim();

            try
            {
                context.SaveChanges();
                _listRole.Clear();
                var roles = GetRoles();
                foreach (var r in roles)
                {
                    _listRole.Add(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\nОшибка редактирования данных!\n" +
                    ex.Message, "Предупреждение");
            }
        }

        public void DeleteRole(Role delRole)
        {
            try
            {
                Role role = context.Roles.Find(delRole.Id);
                if (role != null)
                {
                    // Проверяем, не используется ли должность в сотрудниках
                    bool hasEmployees = context.Persons.Any(p => p.RoleId == role.Id);
                    if (hasEmployees)
                    {
                        MessageBox.Show("Невозможно удалить должность, так как она используется сотрудниками.", 
                            "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    context.Roles.Remove(role);
                    context.SaveChanges();
                
                    _listRole.Clear();
                    var roles = GetRoles();
                    foreach (var r in roles)
                    {
                        _listRole.Add(r);
                    }

                    MessageBox.Show("Должность успешно удалена.", "Информация", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Должность не найдена в базе данных.", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении должности: {ex.Message}", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 