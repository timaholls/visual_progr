using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using _4_1.Model;

namespace _4_1.ViewModel
{
    public class RoleViewModel : ViewModelBase
    {
        private ObservableCollection<Role> _listRole = new ObservableCollection<Role>();
        
        public ObservableCollection<Role> ListRole
        {
            get { return _listRole; }
            set { SetProperty(ref _listRole, value); }
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
        
        public void AddRole(Role role)
        {
            // Add to collection
            ListRole.Add(role);
        }
        
        public void UpdateRole(Role updatedRole)
        {
            // Find the role to update
            var role = ListRole.FirstOrDefault(r => r.Id == updatedRole.Id);
            if (role == null) return;
            
            // Update role properties
            role.NameRole = updatedRole.NameRole;
        }
        
        public void DeleteRole(int id)
        {
            // Find the role to delete
            var role = ListRole.FirstOrDefault(r => r.Id == id);
            if (role == null) return;
            
            // Remove from collection
            ListRole.Remove(role);
        }
    }
} 