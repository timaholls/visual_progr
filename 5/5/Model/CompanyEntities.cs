using System;
using System.Data.Entity;

namespace MyApp.Model
{
    public class CompanyEntities : DbContext
    {
        public CompanyEntities() : base("name=CompanyEntities")
        {
            // примечание (App.config или Web.config): По умолчанию эта
            // строка подключения указывает на базу данных LocalDB.
            // Если требуется выбрать другую базу данных или поставщик
            // баз данных, измените строку подключения "CompanyEntities"
            // в файле конфигурации приложения.
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
} 