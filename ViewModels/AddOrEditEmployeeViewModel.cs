using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModels
{
    public class AddOrEditEmployeeViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private ObservableCollection<PhoneNumber> _phoneNumbers;
        public IEnumerable<PhoneNumber> PhoneNumbers => _phoneNumbers;

        private ObservableCollection<Email> _emails;
        public IEnumerable<Email> Emails => _emails;


        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

        private PhoneNumber _selectedPhoneNumber;
        public PhoneNumber SelectedPhoneNumber
        {
            get
            {
                return _selectedPhoneNumber;
            }
            set
            {
                _selectedPhoneNumber = value;
                OnPropertyChanged(nameof(SelectedPhoneNumber));
                OnPropertyChanged(nameof(CanApplyRemovePhoneNumberButton));
            }
        }

        private Email _selectedEmail;
        public Email SelectedEmail
        {
            get
            {
                return _selectedEmail;
            }
            set
            {
                _selectedEmail = value;
                OnPropertyChanged(nameof(SelectedEmail));
                OnPropertyChanged(nameof(CanApplyRemoveEmailButton));
            }
        }


        private string _pageTitle;
        public string PageTitle
        { 
            get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }


        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;

                ClearErrors(_employeePropertyErrors, nameof(FirstName));
                if(string.IsNullOrEmpty(_firstName))
                {
                    AddError(_employeePropertyErrors, nameof(FirstName), "The First Name field can't be blank.");
                }
                else if(_firstName.Length > 20)
                {
                    AddError(_employeePropertyErrors, nameof(FirstName), "The First Name field can't be longer than 20 characters.");
                }

                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;

                ClearErrors(_employeePropertyErrors, nameof(LastName));
                if (string.IsNullOrEmpty(_lastName))
                {
                    AddError(_employeePropertyErrors, nameof(LastName), "The Last Name field can't be blank.");
                }
                else if (_lastName.Length > 30)
                {
                    AddError(_employeePropertyErrors, nameof(LastName), "The Last Name field can't be longer than 30 characters.");
                }

                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _position;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;

                ClearErrors(_employeePropertyErrors, nameof(Position));
                if (string.IsNullOrEmpty(_position))
                {
                    AddError(_employeePropertyErrors, nameof(Position), "The Position field can't be blank.");
                }
                else if (_position.Length > 25)
                {
                    AddError(_employeePropertyErrors, nameof(Position), "The Position field can't be longer than 25 characters.");
                }

                OnPropertyChanged(nameof(Position));
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;

                ClearErrors(_employeePropertyErrors, nameof(City));
                if (string.IsNullOrEmpty(_city))
                {
                    AddError(_employeePropertyErrors, nameof(City), "The City field can't be blank.");
                }
                else if (_city.Length > 30)
                {
                    AddError(_employeePropertyErrors, nameof(City), "The City field can't be longer than 30 characters.");
                }

                OnPropertyChanged(nameof(City));
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;

                ClearErrors(_employeePropertyErrors, nameof(ZipCode));
                if (string.IsNullOrEmpty(_zipCode))
                {
                    AddError(_employeePropertyErrors, nameof(ZipCode), "The Zip Code field can't be blank.");
                }
                else if (_zipCode.Length > 10)
                {
                    AddError(_employeePropertyErrors, nameof(ZipCode), "The Zip Code field can't be longer than 10 characters.");
                }

                OnPropertyChanged(nameof(ZipCode));
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;

                ClearErrors(_employeePropertyErrors, nameof(Street));
                if (string.IsNullOrEmpty(_street))
                {
                   AddError(_employeePropertyErrors, nameof(Street), "The Street field can't be blank.");
                }
                else if (_street.Length > 35)
                {
                    AddError(_employeePropertyErrors, nameof(Street), "The Street field can't be longer than 35 characters.");
                }

                OnPropertyChanged(nameof(Street));
            }
        }


        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;

                ClearErrors(_emailPropertyErrors, nameof(Email));
                if (string.IsNullOrEmpty(_email))
                {
                    AddError(_emailPropertyErrors, nameof(Email), "The Email field can't be blank.");
                }
                else if (_email.Length > 20)
                {
                    AddError(_emailPropertyErrors, nameof(Email), "The Email field can't be longer than 20 characters.");
                }

                OnPropertyChanged(nameof(Email));
            }
        }

        private string _emailDescription;
        public string EmailDescription
        {
            get
            {
                return _emailDescription;
            }
            set
            {
                _emailDescription = value;

                ClearErrors(_emailPropertyErrors, nameof(EmailDescription));
                if (!string.IsNullOrEmpty(_emailDescription))
                {
                    if (_emailDescription.Length > 30)
                    {
                        AddError(_emailPropertyErrors, nameof(EmailDescription), "The Email Description field can't be longer than 30 characters.");
                    }
                }

                OnPropertyChanged(nameof(EmailDescription));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;

                ClearErrors(_phoneNumberPropertyErrors, nameof(PhoneNumber));
                if (string.IsNullOrEmpty(_phoneNumber))
                {
                    AddError(_phoneNumberPropertyErrors, nameof(PhoneNumber), "The Phone Number field can't be blank.");
                }
                else if (_phoneNumber.Length > 20)
                {
                    AddError(_phoneNumberPropertyErrors, nameof(PhoneNumber), "The Phone Number field can't be longer than 20 characters.");
                }

                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _phoneNumberDescription;
        public string PhoneNumberDescription
        {
            get
            {
                return _phoneNumberDescription;
            }
            set
            {
                _phoneNumberDescription = value;

                ClearErrors(_phoneNumberPropertyErrors, nameof(PhoneNumberDescription));
                if (!string.IsNullOrEmpty(_phoneNumberDescription))
                {
                    if (_phoneNumberDescription.Length > 30)
                    {
                        AddError(_phoneNumberPropertyErrors, nameof(PhoneNumberDescription), "The Phone Number Description field can't be longer than 30 characters.");
                    }
                }

                OnPropertyChanged(nameof(PhoneNumberDescription));
            }
        }


        public ICommand SaveEmployeeCommand { get; }
        public ICommand CancelCommand { get; } 
        public ICommand AddPhoneNumberCommand { get; }
        public ICommand RemovePhoneNumberCommand { get; }
        public ICommand AddEmailCommand { get; }
        public ICommand RemoveEmailCommand { get; }

        private readonly Dictionary<string, List<string>> _propertyErrors;
        private readonly Dictionary<string, List<string>> _employeePropertyErrors;
        private readonly Dictionary<string, List<string>> _phoneNumberPropertyErrors;
        private readonly Dictionary<string, List<string>> _emailPropertyErrors;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool CanApplySaveEmployeeButton => !HasEmployeePropertyErrors;
        public bool CanApplyAddPhoneNumberButton => !HasPhoneNumberPropertyErrors;
        public bool CanApplyRemovePhoneNumberButton => SelectedPhoneNumber != null;
        public bool CanApplyAddEmailButton => !HasEmailPropertyErrors;
        public bool CanApplyRemoveEmailButton => SelectedEmail != null;

        public bool HasErrors => HasEmployeePropertyErrors || HasPhoneNumberPropertyErrors || HasEmployeePropertyErrors;
        public bool HasEmployeePropertyErrors => _employeePropertyErrors.Any();
        public bool HasPhoneNumberPropertyErrors => _phoneNumberPropertyErrors.Any();
        public bool HasEmailPropertyErrors => _emailPropertyErrors.Any();

        public AddOrEditEmployeeViewModel(EmployerBriefcase employerBriefcase, NavigationStore navigationStore, Func<EmployeeListingViewModel> createEmployeeListingViewModel)
        {
            _phoneNumbers = new ObservableCollection<PhoneNumber>();
            _emails = new ObservableCollection<Email>();
            _propertyErrors = new Dictionary<string, List<string>>();
            _employeePropertyErrors = new Dictionary<string, List<string>>();
            _phoneNumberPropertyErrors = new Dictionary<string, List<string>>();
            _emailPropertyErrors = new Dictionary<string, List<string>>();

            SaveEmployeeCommand = new AddOrEditEmployeeCommand(this, employerBriefcase);
            CancelCommand = new NavigateCommand(navigationStore, createEmployeeListingViewModel);
            AddPhoneNumberCommand = new RelayCommand(AddPhoneNumber);
            RemovePhoneNumberCommand = new RelayCommand(RemovePhoneNumber);
            AddEmailCommand = new RelayCommand(AddEmail);
            RemoveEmailCommand = new RelayCommand(RemoveEmail);

            AddErrors();
            FillView(employerBriefcase.CurrentEmployee);
        }

        private void AddErrors()
        {
            AddError(_employeePropertyErrors, nameof(FirstName), "The First Name field can't be blank.");
            AddError(_employeePropertyErrors, nameof(LastName), "The Last Name field can't be blank.");
            AddError(_employeePropertyErrors, nameof(Position), "The Position field can't be blank.");
            AddError(_employeePropertyErrors, nameof(City), "The City field can't be blank.");
            AddError(_employeePropertyErrors, nameof(ZipCode), "The Zip Code field can't be blank.");
            AddError(_employeePropertyErrors, nameof(Street), "The Street field can't be blank.");

            AddError(_phoneNumberPropertyErrors, nameof(PhoneNumber), "The Phone Number field can't be blank.");

            AddError(_emailPropertyErrors, nameof(Email), "The Email field can't be blank.");
        }

        private void FillView(Employee employee)
        {
            if (employee == null)
            {
                PageTitle = "Add Employee";
            }
            else
            {
                Employee = employee;
                PageTitle = "Edit Employee";
                FirstName = employee.FirstName;
                LastName = employee.LastName;
                Position = employee.Position;
                City = employee.City;
                ZipCode = employee.ZipCode;
                Street = employee.Street;

                _phoneNumbers = new ObservableCollection<PhoneNumber>(employee.PhoneNumbers);
                _emails = new ObservableCollection<Email>(employee.Emails);
            }
        }

        public Employee CreateEmployee(int id)
        {
            return new Employee(
                id,
                FirstName,
                LastName,
                Position,
                City,
                ZipCode,
                Street,
                new List<PhoneNumber>(PhoneNumbers),
                new List<Email>(Emails)
                );
        }

        private void AddPhoneNumber()
        {
            PhoneNumber ph = new PhoneNumber(0, PhoneNumber, PhoneNumberDescription);

            _phoneNumbers.Add(ph);

            PhoneNumber = "";
            PhoneNumberDescription = "";
        }

        private void RemovePhoneNumber()
        {
           if(SelectedPhoneNumber != null)
           {
                _phoneNumbers.Remove(SelectedPhoneNumber);
           }
        }

        private void AddEmail()
        {
            Email email = new Email(0, Email, EmailDescription);

            _emails.Add(email);

            Email = "";
            EmailDescription = "";
        }

        private void RemoveEmail()
        {
            if(SelectedEmail != null)
            {
                _emails.Remove(SelectedEmail);
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, new List<string>());
        }

        public void AddError(Dictionary<string, List<string>> errors, string propertyName, string errorMessage)
        {
            if (!errors.ContainsKey(propertyName))
            {
                errors.Add(propertyName, new List<string>());
                _propertyErrors.Add(propertyName, new List<string>());
            }

            errors[propertyName].Add(errorMessage);
            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

            OnPropertyChanged(nameof(CanApplySaveEmployeeButton));
            OnPropertyChanged(nameof(CanApplyAddPhoneNumberButton));
            OnPropertyChanged(nameof(CanApplyAddEmailButton));
        }

        public void ClearErrors(Dictionary<string, List<string>> errors, string propertyName)
        {
            if (errors.Remove(propertyName))
            {
                _propertyErrors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
