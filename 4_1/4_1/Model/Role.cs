using System;

namespace _4_1.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string NameRole { get; set; }

        public Role(int id, string nameRole)
        {
            Id = id;
            NameRole = nameRole;
        }

        public bool RolePredicate(Role role)
        {
            return role.Id == Id;
        }
    }
} 