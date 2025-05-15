using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using _4_1.Helper;
using _4_1.Model;
using _4_1.View;

namespace _4_1.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private ObservableCollection<PersonDPO> _listPerson = new ObservableCollection<PersonDPO>();
        private PersonDPO _selectedPersonDPO;
        
        // Команды
        private RelayCommand _addPerson;
        private RelayCommand _editPerson;
        private RelayCommand _deletePerson;
        
        public RelayCommand AddPerson
        {
            get
            {
                return _addPerson ?? (_addPerson = new RelayCommand(obj =>
                {
                    // Формирование кода нового сотрудника
                    int personId = GetNextPersonId();
                    PersonDPO per = new PersonDPO(
                        personId,
                        "", // Роль будет выбрана в окне редактирования
                        "",
                        "",
                        DateTime.Now
                    );
                    
                    EditEmployeeWindow wnPerson = new EditEmployeeWindow(per, _vmRole);
                    if (wnPerson.ShowDialog() == true)
                    {
                        // Находим ID роли по имени роли
                        int roleId = 1; // По умолчанию
                        foreach (var role in _vmRole)
                        {
                            if (role.NameRole == per.Role)
                            {
                                roleId = role.Id;
                                break;
                            }
                        }
                        
                        // Создаем новый объект Person для внутреннего списка
                        Person p = new Person(
                            per.Id,
                            roleId,
                            per.FirstName,
                            per.LastName,
                            per.Birthday
                        );
                        
                        _vmPerson.Add(p);
                        FillPersonDPO();
                    }
                }));
            }
        }
        
        public RelayCommand EditPerson
        {
            get
            {
                return _editPerson ?? (_editPerson = new RelayCommand(obj =>
                {
                    PersonDPO per = SelectedPersonDPO;
                    // Создаем копию для редактирования
                    PersonDPO tempPerson = new PersonDPO(
                        per.Id,
                        per.Role,
                        per.FirstName,
                        per.LastName,
                        per.Birthday
                    );
                    
                    EditEmployeeWindow wnPerson = new EditEmployeeWindow(tempPerson, _vmRole);
                    if (wnPerson.ShowDialog() == true)
                    {
                        // Применяем изменения к оригинальному объекту
                        per.Role = tempPerson.Role;
                        per.FirstName = tempPerson.FirstName;
                        per.LastName = tempPerson.LastName;
                        per.Birthday = tempPerson.Birthday;
                        
                        // Находим ID роли по имени роли
                        int roleId = 1; // По умолчанию
                        foreach (var role in _vmRole)
                        {
                            if (role.NameRole == per.Role)
                            {
                                roleId = role.Id;
                                break;
                            }
                        }
                        
                        // Находим исходный объект Person для обновления
                        Person p = _vmPerson.FirstOrDefault(x => x.Id == per.Id);
                        if (p != null)
                        {
                            p.RoleId = roleId;
                            p.FirstName = per.FirstName;
                            p.LastName = per.LastName;
                            p.Birthday = per.Birthday;
                        }
                        
                        FillPersonDPO();
                    }
                }, (obj) => SelectedPersonDPO != null));
            }
        }
        
        public RelayCommand DeletePerson
        {
            get
            {
                return _deletePerson ?? (_deletePerson = new RelayCommand(obj =>
                {
                    PersonDPO person = SelectedPersonDPO;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по сотруднику: \n" + person.LastName + " " +
                        person.FirstName, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    
                    if (result == MessageBoxResult.OK)
                    {
                        // Удаление данных из списка отображения
                        _listPerson.Remove(person);
                        // Удаление данных из списка объектов
                        Person p = _vmPerson.FirstOrDefault(x => x.Id == person.Id);
                        if (p != null)
                        {
                            _vmPerson.Remove(p);
                        }
                    }
                }, (obj) => SelectedPersonDPO != null));
            }
        }
        
        public ObservableCollection<PersonDPO> ListPerson
        {
            get { return _listPerson; }
            set { SetProperty(ref _listPerson, value); }
        }

        public PersonDPO SelectedPersonDPO
        {
            get { return _selectedPersonDPO; }
            set
            {
                SetProperty(ref _selectedPersonDPO, value);
                OnPropertyChanged("SelectedPersonDPO");
            }
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
    }
} 