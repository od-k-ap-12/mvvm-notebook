using mvvm_notebook.commands;
using mvvm_notebook.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Input;

namespace mvvm_notebook.viewmodels
{
    [Serializable]
    [DataContract]
    internal class PersonViewModel:ViewModelBase
    {
        [DataMember]
        public Person Person;

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
