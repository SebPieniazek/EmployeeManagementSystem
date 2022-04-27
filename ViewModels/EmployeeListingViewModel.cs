using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Stores;
using System;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }

        public EmployeeListingViewModel(NavigationStore navigationStore, Func<AddOrEditEmployeeViewModel> createAddOrEditEmployeeViewModel)
        {

            AddEmployeeCommand = new NavigateCommand(navigationStore, createAddOrEditEmployeeViewModel);
            EditEmployeeCommand = new NavigateCommand(navigationStore, createAddOrEditEmployeeViewModel);
        }
    }
}
