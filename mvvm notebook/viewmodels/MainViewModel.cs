using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvm_notebook.models;

namespace mvvm_notebook.viewmodels
{
    internal class MainViewModel
    {
        public ObservableCollection<PersonViewModel> PeopleList { get; set; }

        public MainViewModel(List<Person> people)
        {
            PeopleList = new ObservableCollection<PersonViewModel>(people.Select(p => new PersonViewModel(p)));
        }
    }
}
