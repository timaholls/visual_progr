using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Data.Entity;
using MyApp.Model;

namespace MyApp.ViewModel
{
    public class PersonViewModel
    {
        private ObservableCollection<Person> _listPerson;
        private CompanyEntities context;

        public PersonViewModel()
        {
            _listPerson = new ObservableCollection<Person>();
            context = new CompanyEntities();
            _listPerson = GetPersons();
        }

        public ObservableCollection<Person> ListPerson 
        { 
            get { return _listPerson; } 
            private set { _listPerson = value; }
        }

        private ObservableCollection<Person> GetPersons()
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>();
            using (var context = new CompanyEntities())
            {
                var query = from per in context.Persons.Include(p => p.Role)
                            orderby per.LastName
                            select per;

                if (query.Count() != 0)
                {
                    foreach (var p in query)
                    {
                        persons.Add(p);
                    }
                }
                return persons;
            }
        }

        public void AddPerson(Person newPerson)
        {            
            context.Persons.Add(newPerson);
            context.SaveChanges();
            _listPerson.Clear();
            var persons = GetPersons();
            foreach (var person in persons)
            {
                _listPerson.Add(person);
            }
        }

        public void EditPerson(Person editPerson)
        {
            Person person = context.Persons.Find(editPerson.Id);
            
            if (person.RoleId != editPerson.RoleId)
                person.RoleId = editPerson.RoleId;
            if (person.FirstName != editPerson.FirstName)
                person.FirstName = editPerson.FirstName;
            if (person.LastName != editPerson.LastName)
                person.LastName = editPerson.LastName;
            if (person.Birthday != editPerson.Birthday)
                person.Birthday = editPerson.Birthday;

            try
            {
                context.SaveChanges();
                _listPerson.Clear();
                var persons = GetPersons();
                foreach (var p in persons)
                {
                    _listPerson.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\nОшибка редактирования данных!\n" +
                    ex.Message, "Предупреждение");
            }
        }

        public void DeletePerson(Person delPerson)
        {
            try
            {
                Person person = context.Persons.Find(delPerson.Id);
                
                if (person != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Удалить данные по сотруднику: {person.LastName} {person.FirstName}?",
                        "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    
                    if (result == MessageBoxResult.OK)
                    {
                        context.Persons.Remove(person);
                        context.SaveChanges();
                        
                        // Обновляем коллекцию
                        var personToRemove = _listPerson.FirstOrDefault(p => p.Id == delPerson.Id);
                        if (personToRemove != null)
                        {
                            _listPerson.Remove(personToRemove);
                        }
                        
                        MessageBox.Show("Данные сотрудника успешно удалены.", 
                            "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден в базе данных.", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении данных сотрудника: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 