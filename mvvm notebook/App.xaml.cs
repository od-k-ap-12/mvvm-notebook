using mvvm_notebook.viewmodels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using mvvm_notebook.models;

namespace mvvm_notebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Name1", "Address1", "1"),
                new Person("Name2", "Address2", "2"),
                new Person("Name3", "Address3", "3"),
                new Person("Name4", "Address4", "4")
            };

            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel(people);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
