using EmployeeManagementSystem.Stores;
using EmployeeManagementSystem.ViewModels;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(INavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
