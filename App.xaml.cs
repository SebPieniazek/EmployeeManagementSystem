using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.Stores;
using EmployeeManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly DbContextsFactory _dbContextsFactory;

        public App()
        {
            _navigationStore = new NavigationStore();

            string connectionString = @"Host=pgsql14.server758561.nazwa.pl;Database=server758561_EmployeeManagementSystem;Username=server758561_EmployeeManagementSystem;Password=EMSGreen1!";
            _dbContextsFactory = new DbContextsFactory(connectionString);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new EmployeeListingViewModel(_navigationStore, CreateAddOrEditEmployeeViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddOrEditEmployeeViewModel CreateAddOrEditEmployeeViewModel()
        {
            return new AddOrEditEmployeeViewModel(_navigationStore, CreateEmployeeListingViewModel);
        }

        private EmployeeListingViewModel CreateEmployeeListingViewModel()
        {
            return new EmployeeListingViewModel(_navigationStore, CreateAddOrEditEmployeeViewModel);
        }
    }
}
