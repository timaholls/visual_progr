using System;
using System.Collections.Generic;

namespace MyApp.Model
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Код сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName { get; set; } // имя

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string LastName { get; set; } // фамилия

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; } // дата рождения
        
        /// <summary>
        /// Код должности для связи с сущностью Role
        /// </summary>
        public int RoleId { get; set; }
        
        /// <summary>
        /// Должность
        /// </summary>
        public virtual Role Role { get; set; }
    }
} 