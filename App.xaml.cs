using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Stores;
using EmployeeManagementSystem.ViewModels;
using System.Windows;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly INavigationStore _navigationStore;
        private readonly DbContextsFactory _dbContextsFactory;
        private readonly IEmployerBriefcase _employerBriefcase;

        public App()
        {
            _navigationStore = new NavigationStore();

            string connectionString = @"Host=pgsql14.server758561.nazwa.pl;Database=server758561_EmployeeManagementSystem;Username=server758561_EmployeeManagementSystem;Password=EMSGreen1!";
            _dbContextsFactory = new DbContextsFactory(connectionString);
            _employerBriefcase = new EmployerBriefcase(_dbContextsFactory);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new EmployeeListingViewModel(_employerBriefcase, _navigationStore, CreateAddOrEditEmployeeViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddOrEditEmployeeViewModel CreateAddOrEditEmployeeViewModel()
        {
            return new AddOrEditEmployeeViewModel(_employerBriefcase, _navigationStore, CreateEmployeeListingViewModel);
        }

        private EmployeeListingViewModel CreateEmployeeListingViewModel()
        {
            return new EmployeeListingViewModel(_employerBriefcase, _navigationStore, CreateAddOrEditEmployeeViewModel);
        }
    }
}
