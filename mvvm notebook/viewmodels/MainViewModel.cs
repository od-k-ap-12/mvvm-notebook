using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvm_notebook.commands;
using System.Windows.Input;
using mvvm_notebook.models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace mvvm_notebook.viewmodels
{
    [Serializable]
    [DataContract]
    internal class MainViewModel
    {
        public ObservableCollection<PersonViewModel> PeopleList { get; set; }
        private DelegateCommand addPersonCommand;
        private DelegateCommand deletePersonCommand;
        private DelegateCommand savePeopleCommand;
        private DelegateCommand loadPeopleCommand;

        public MainViewModel(List<Person> people)
        {
            PeopleList = new ObservableCollection<PersonViewModel>(people.Select(p => new PersonViewModel(p)));
        }
        public ICommand AddPersonCommand
        {
            get
            {
                if (addPersonCommand == null)
                {
                    addPersonCommand = new DelegateCommand(param => AddPerson(), null);

                }
                return addPersonCommand;
            }
        }

        private void AddPerson()
        {
            PeopleList.Add(new PersonViewModel(new Person("Кликните, чтобы редактировать!", "", "")));
        }
        public ICommand DeletePersonCommand
        {
            get
            {
                if (deletePersonCommand == null)
                {
                    deletePersonCommand = new DelegateCommand(DeletePerson, null);

                }
                return deletePersonCommand;
            }
        }

        private void DeletePerson(object obj)
        {
            PeopleList.Remove(obj as PersonViewModel);
        }

        public ICommand SaveToFileCommand
        {
            get
            {
                if (savePeopleCommand == null)
                {
                    savePeopleCommand = new DelegateCommand(param => SaveToFile(), null);

                }
                return savePeopleCommand;
            }
        }

        private void SaveToFile()
        {
            List<Person> PeopleToSave = new List<Person>();
            foreach(PersonViewModel p in PeopleList)
            {
                PeopleToSave.Add(p.Person);
            }
            FileStream stream = null;
            DataContractJsonSerializer jsonFormatter = null;
            stream = new FileStream("../../notebook.json", FileMode.Create);
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
            jsonFormatter.WriteObject(stream, PeopleToSave);
            stream.Close();
            MessageBox.Show("Сериализация успешно выполнена!");
        }

        public ICommand LoadFromFileCommand
        {
            get
            {
                if (loadPeopleCommand == null)
                {
                    loadPeopleCommand = new DelegateCommand(param => LoadFromFile(), null);

                }
                return loadPeopleCommand;
            }
        }

        private void LoadFromFile()
        {
            if (File.Exists("../../notebook.json"))
            {
                FileStream stream = null;
                DataContractJsonSerializer jsonFormatter = null;
                stream = new FileStream("../../notebook.json", FileMode.Open);
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
                List<Person> PeopleToLoad = new List<Person>();
                PeopleToLoad = (List<Person>)jsonFormatter.ReadObject(stream);
                PeopleList.Clear();
                foreach (Person p in PeopleToLoad)
                {
                    PeopleList.Add(new PersonViewModel(p));
                }
                stream.Close();
                MessageBox.Show("Десериализация успешно выполнена!");
            }
            else
            {
                MessageBox.Show("Нет доступных сохранений");
            }
        }
    }
}

