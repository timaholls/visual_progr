using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using _4_1.Model;

namespace _4_1.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private ObservableCollection<PersonDPO> _listPerson = new ObservableCollection<PersonDPO>();
        
        public ObservableCollection<PersonDPO> ListPerson
        {
            get { return _listPerson; }
            set { SetProperty(ref _listPerson, value); }
        }

        private ObservableCollection<Person> _vmPerson;
        private ObservableCollection<Role> _vmRole;

        public ObservableCollection<Role> Roles => _vmRole;

        public PersonViewModel()
        {
            _vmPerson = new ObservableCollection<Person>();
            _vmRole = new ObservableCollection<Role>();
            
            // Add sample roles
            _vmRole.Add(new Role(1, "Директор"));
            _vmRole.Add(new Role(2, "Бухгалтер"));
            _vmRole.Add(new Role(3, "Менеджер"));
            
            // Add sample persons
            _vmPerson.Add(new Person(1, 1, "Иван", "Иванов", new DateTime(1980, 2, 28)));
            _vmPerson.Add(new Person(2, 2, "Петр", "Петров", new DateTime(1981, 3, 20)));
            _vmPerson.Add(new Person(3, 3, "Виктор", "Викторов", new DateTime(1982, 4, 15)));
            _vmPerson.Add(new Person(4, 3, "Сидор", "Сидоров", new DateTime(1983, 5, 10)));
            
            FillPersonDPO();
        }
        
        public void FillPersonDPO()
        {
            ListPerson.Clear();
            
            foreach (var p in _vmPerson)
            {
                FindRole finder = new FindRole(p.RoleId);
                Role rol = _vmRole.FirstOrDefault(finder.RolePredicate);
                
                if (rol != null)
                {
                    ListPerson.Add(new PersonDPO(
                        p.Id,
                        rol.NameRole,
                        p.FirstName,
                        p.LastName,
                        p.Birthday
                    ));
                }
                else
                {
                    // If role not found, use "Неизвестно" as role name
                    ListPerson.Add(new PersonDPO(
                        p.Id,
                        "Неизвестно",
                        p.FirstName,
                        p.LastName,
                        p.Birthday
                    ));
                }
            }
        }

        public int GetNextPersonId()
        {
            return _vmPerson.Count > 0 ? _vmPerson.Max(p => p.Id) + 1 : 1;
        }

        public void AddPerson(PersonDPO personDPO)
        {
            // Find the role ID based on role name
            int roleId = 1; // Default
            foreach (var role in _vmRole)
            {
                if (role.NameRole == personDPO.Role)
                {
                    roleId = role.Id;
                    break;
                }
            }

            // Create new Person object
            var newPerson = new Person(
                personDPO.Id,
                roleId,
                personDPO.FirstName,
                personDPO.LastName,
                personDPO.Birthday
            );

            // Add to collection
            _vmPerson.Add(newPerson);
            
            // Refresh the DPO collection
            FillPersonDPO();
        }

        public void UpdatePerson(PersonDPO personDPO)
        {
            // Find the person to update
            var person = _vmPerson.FirstOrDefault(p => p.Id == personDPO.Id);
            if (person == null) return;

            // Find the role ID based on role name
            int roleId = 1; // Default
            foreach (var role in _vmRole)
            {
                if (role.NameRole == personDPO.Role)
                {
                    roleId = role.Id;
                    break;
                }
            }

            // Update person properties
            person.RoleId = roleId;
            person.FirstName = personDPO.FirstName;
            person.LastName = personDPO.LastName;
            person.Birthday = personDPO.Birthday;
            
            // Refresh the DPO collection
            FillPersonDPO();
        }

        public void DeletePerson(int id)
        {
            // Find the person to delete
            var person = _vmPerson.FirstOrDefault(p => p.Id == id);
            if (person == null) return;

            // Remove from collection
            _vmPerson.Remove(person);
            
            // Refresh the DPO collection
            FillPersonDPO();
        }
    }
} 