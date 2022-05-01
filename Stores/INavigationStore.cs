using EmployeeManagementSystem.ViewModels;
using System;

namespace EmployeeManagementSystem.Stores
{
    public interface INavigationStore
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public event Action CurrentViewModelChanged;

        public void OnCurrentViewModelChanged();
    }
}
