using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _4_1.Model
{
    public class PersonDPO : INotifyPropertyChanged
    {
        private int _id;
        private string _role;
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        
        public int Id 
        { 
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public string Role 
        { 
            get { return _role; }
            set 
            { 
                _role = value;
                OnPropertyChanged("Role");
            }
        }
        
        public string FirstName 
        { 
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        
        public string LastName 
        { 
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        
        public DateTime Birthday 
        { 
            get { return _birthday; }
            set 
            { 
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public PersonDPO(int id, string role, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
} 