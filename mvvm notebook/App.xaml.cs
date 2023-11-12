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
            List<Person> people = new List<Person>();

            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel(people);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
