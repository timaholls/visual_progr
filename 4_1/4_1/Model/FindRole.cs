using System;
using System.Windows;
using _4_1.Model;

namespace _4_1.Model
{
    public class FindRole
    {
        int id;
        public FindRole(int id)
        {
            this.id = id;
        }

        public bool RolePredicate(Role role)
        {
            return role.Id == id;
        }
    }
} 