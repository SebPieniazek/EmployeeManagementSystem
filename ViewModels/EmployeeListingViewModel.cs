using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Employee> _employees;
        public IEnumerable<Employee> Employees => _employees;

        private readonly IEmployerBriefcase _employerBriefcase;

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                OnPropertyChanged(nameof(CanApplyEditOrRemoveButton));
            }
        }

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand RemoveEmployeeCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand LoadEmployeesCommand { get; }

        public bool CanApplyEditOrRemoveButton => SelectedEmployee != null;

        public EmployeeListingViewModel(IEmployerBriefcase employerBriefcase, INavigationStore navigationStore, Func<AddOrEditEmployeeViewModel> createAddOrEditEmployeeViewModel)
        {
            _employees = new ObservableCollection<Employee>();
            _employerBriefcase = employerBriefcase;

            NavigateCommand = new NavigateCommand(navigationStore, createAddOrEditEmployeeViewModel);
            AddEmployeeCommand = new RelayCommand(NavigateToAddEmployeeView);
            EditEmployeeCommand = new RelayCommand(NavigateToEditEmployeeView);
            RemoveEmployeeCommand = new RemoveEmployeeCommand(this, employerBriefcase);
            CloseWindowCommand = new CloseWindowCommand();
            LoadEmployeesCommand = new LoadEmployeesCommand(this, employerBriefcase);
            LoadEmployeesCommand.Execute(null);
        }

        private void NavigateToAddEmployeeView()
        {
            _employerBriefcase.EmployeeToEdit = null;
            NavigateCommand.Execute(null);
        }

        private void NavigateToEditEmployeeView()
        {
            _employerBriefcase.EmployeeToEdit = SelectedEmployee;
            NavigateCommand.Execute(null);
        }

        public void UpdateList(IEnumerable<Employee> employees)
        {
            _employees.Clear();
            int i = 1;

            foreach(Employee employee in employees)
            {
                employee.Index = i++;
                _employees.Add(employee);
            }
        }
    }
}
