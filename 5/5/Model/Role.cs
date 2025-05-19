using System;
using System.Collections.Generic;

namespace MyApp.Model
{
    /// <summary>
    /// класс должности сотрудника
    /// </summary>
    public class Role
    {
        public Role()
        {
            Persons = new List<Person>();
        }
        
        /// <summary>
        /// Код должности
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// наименование должности
        /// </summary>
        public string NameRole { get; set; }

        /// <summary>
        /// коллекция Persons для связи с классом Person
        /// </summary>
        public virtual ICollection<Person> Persons { get; set; }
    }
} 