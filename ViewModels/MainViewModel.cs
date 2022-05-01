using EmployeeManagementSystem.Stores;

namespace EmployeeManagementSystem.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;


        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(INavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
