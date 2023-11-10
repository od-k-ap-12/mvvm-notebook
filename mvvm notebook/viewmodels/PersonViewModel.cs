using mvvm_notebook.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_notebook.viewmodels
{
    internal class PersonViewModel:ViewModelBase
    {
        private Person Person;

        public PersonViewModel(Person person)
        {
            this.Person = person;
        }

        public string FullName
        {
            get { return Person.FullName; }
            set
            {
                Person.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Address
        {
            get { return Person.Address; }
            set
            {
                Person.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Phone
        {
            get { return Person.Phone; }
            set
            {
                Person.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
    }
}
