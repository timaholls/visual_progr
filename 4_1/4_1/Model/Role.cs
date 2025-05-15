using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _4_1.Model
{
    public class Role : INotifyPropertyChanged
    {
        private int _id;
        private string _nameRole;
        
        public int Id 
        { 
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public string NameRole 
        { 
            get { return _nameRole; }
            set 
            { 
                _nameRole = value;
                OnPropertyChanged("NameRole");
            }
        }

        public Role(int id, string nameRole)
        {
            Id = id;
            NameRole = nameRole;
        }

        public bool RolePredicate(Role role)
        {
            return role.Id == Id;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
} 