using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModels
{
    public class AddOrEditEmployeeViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; }

        public AddOrEditEmployeeViewModel(NavigationStore navigationStore, Func<EmployeeListingViewModel> createEmployeeListingViewModel)
        {
            CancelCommand = new NavigateCommand(navigationStore, createEmployeeListingViewModel);
        }
    }
}
