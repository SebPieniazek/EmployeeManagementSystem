﻿using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
                OnPropertyChanged(nameof(ShowRemovePhoneNumberButtonToolTip));
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
                OnPropertyChanged(nameof(ShowRemoveEmailButtonToolTip));
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
                else if(_firstName.Length > 40)
                {
                    AddError(_employeePropertyErrors, nameof(FirstName), "The First Name field can't be longer than 40 characters.");
                }
                FillSaveButtonToolTip();

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
                else if (_lastName.Length > 40)
                {
                    AddError(_employeePropertyErrors, nameof(LastName), "The Last Name field can't be longer than 40 characters.");
                }
                FillSaveButtonToolTip();

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
                else if (_position.Length > 40)
                {
                    AddError(_employeePropertyErrors, nameof(Position), "The Position field can't be longer than 40 characters.");
                }
                FillSaveButtonToolTip();

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
                FillSaveButtonToolTip();

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
                FillSaveButtonToolTip();

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
                FillSaveButtonToolTip();

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
                else if (_email.Length > 40)
                {
                    AddError(_emailPropertyErrors, nameof(Email), "The Email field can't be longer than 40 characters.");
                }

                FillAddEmailButtonToolTip();
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
                FillAddEmailButtonToolTip();

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
                FillAddPhoneNumberButtonToolTip();

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
                FillAddPhoneNumberButtonToolTip();

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


        private string _saveButtonToolTip;
        public string SaveButtonToolTip
        {
            get
            {
                return _saveButtonToolTip;
            }
            set
            {
                _saveButtonToolTip = value;
                OnPropertyChanged(nameof(SaveButtonToolTip));
            }
        }

        private string _addPhoneNumberButtonToolTip;
        public string AddPhoneNumberButtonToolTip
        {
            get
            {
                return _addPhoneNumberButtonToolTip;
            }
            set
            {
                _addPhoneNumberButtonToolTip = value;
                OnPropertyChanged(nameof(AddPhoneNumberButtonToolTip));
            }
        }

        private string _removePhoneNumberButtonToolTip;
        public string RemovePhoneNumberButtonToolTip
        {
            get
            {
                return _removePhoneNumberButtonToolTip;
            }
            set
            {
                _removePhoneNumberButtonToolTip = value;
                OnPropertyChanged(nameof(RemovePhoneNumberButtonToolTip));
            }
        }

        private string _addEmailButtonToolTip;
        public string AddEmailButtonToolTip
        {
            get
            {
                return _addEmailButtonToolTip;
            }
            set
            {
                _addEmailButtonToolTip = value;
                OnPropertyChanged(nameof(AddEmailButtonToolTip));
            }
        }

        private string _removeEmailButtonToolTip;
        public string RemoveEmailButtonToolTip
        {
            get
            {
                return _removeEmailButtonToolTip;
            }
            set
            {
                _removeEmailButtonToolTip = value;
                OnPropertyChanged(nameof(RemoveEmailButtonToolTip));
            }
        }

        public bool ShowSaveButtonToolTip => HasEmployeePropertyErrors;
        public bool ShowAddPhoneNumberButtonToolTip => HasPhoneNumberPropertyErrors;
        public bool ShowRemovePhoneNumberButtonToolTip => SelectedPhoneNumber == null;
        public bool ShowAddEmailButtonToolTip => HasEmailPropertyErrors;
        public bool ShowRemoveEmailButtonToolTip => SelectedEmail == null;

        public bool CanApplySaveEmployeeButton => !HasEmployeePropertyErrors;
        public bool CanApplyAddPhoneNumberButton => !HasPhoneNumberPropertyErrors;
        public bool CanApplyRemovePhoneNumberButton => SelectedPhoneNumber != null;
        public bool CanApplyAddEmailButton => !HasEmailPropertyErrors;
        public bool CanApplyRemoveEmailButton => SelectedEmail != null;

        public bool HasErrors => HasEmployeePropertyErrors || HasPhoneNumberPropertyErrors || HasEmployeePropertyErrors;
        public bool HasEmployeePropertyErrors => _employeePropertyErrors.Any();
        public bool HasPhoneNumberPropertyErrors => _phoneNumberPropertyErrors.Any();
        public bool HasEmailPropertyErrors => _emailPropertyErrors.Any();

        public AddOrEditEmployeeViewModel(IEmployerBriefcase employerBriefcase, INavigationStore navigationStore, Func<EmployeeListingViewModel> createEmployeeListingViewModel)
        {
            _phoneNumbers = new ObservableCollection<PhoneNumber>();
            _emails = new ObservableCollection<Email>();

            _propertyErrors = new Dictionary<string, List<string>>();
            _employeePropertyErrors = new Dictionary<string, List<string>>();
            _phoneNumberPropertyErrors = new Dictionary<string, List<string>>();
            _emailPropertyErrors = new Dictionary<string, List<string>>();

            RemoveEmailButtonToolTip = "Select email";
            RemovePhoneNumberButtonToolTip = "Select phone number";

            SaveEmployeeCommand = new AddOrEditEmployeeCommand(this, employerBriefcase);
            CancelCommand = new NavigateCommand(navigationStore, createEmployeeListingViewModel);
            AddPhoneNumberCommand = new RelayCommand(AddPhoneNumber);
            RemovePhoneNumberCommand = new RelayCommand(RemovePhoneNumber);
            AddEmailCommand = new RelayCommand(AddEmail);
            RemoveEmailCommand = new RelayCommand(RemoveEmail);

            AddErrors();
            FillView(employerBriefcase.EmployeeToEdit);
        }

        public override void Dispose()
        {
            base.Dispose();
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

        private void AddErrors()
        {
            AddError(_employeePropertyErrors, nameof(FirstName), "The First Name field can't be blank.");
            AddError(_employeePropertyErrors, nameof(LastName), "The Last Name field can't be blank.");
            AddError(_employeePropertyErrors, nameof(Position), "The Position field can't be blank.");
            AddError(_employeePropertyErrors, nameof(City), "The City field can't be blank.");
            AddError(_employeePropertyErrors, nameof(ZipCode), "The Zip Code field can't be blank.");
            AddError(_employeePropertyErrors, nameof(Street), "The Street field can't be blank.");
            FillSaveButtonToolTip();

            AddError(_phoneNumberPropertyErrors, nameof(PhoneNumber), "The Phone Number field can't be blank.");
            FillAddPhoneNumberButtonToolTip();

            AddError(_emailPropertyErrors, nameof(Email), "The Email field can't be blank.");
            FillAddEmailButtonToolTip();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, new List<string>());
        }

        private void AddError(Dictionary<string, List<string>> errors, string propertyName, string errorMessage)
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
            OnPropertyChanged(nameof(ShowSaveButtonToolTip));
            OnPropertyChanged(nameof(ShowAddPhoneNumberButtonToolTip));
            OnPropertyChanged(nameof(ShowAddEmailButtonToolTip));
        }

        private void ClearErrors(Dictionary<string, List<string>> errors, string propertyName)
        {
            if (errors.Remove(propertyName))
            {
                _propertyErrors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void FillAddEmailButtonToolTip()
        {
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<string, List<string>> list in _emailPropertyErrors)
            {
                foreach(string str in list.Value)
                {
                    sb.Append(str);
                    sb.Append(" \n");
                }
            }
            AddEmailButtonToolTip = sb.ToString();
        }

        private void FillAddPhoneNumberButtonToolTip()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, List<string>> list in _phoneNumberPropertyErrors)
            {
                foreach(string str in list.Value)
                {
                    sb.Append(str);
                    sb.Append(" \n");
                }
            }
            AddPhoneNumberButtonToolTip = sb.ToString();
        }

        private void FillSaveButtonToolTip()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, List<string>> list in _employeePropertyErrors)
            {
                foreach (string str in list.Value)
                {
                    sb.Append(str);
                    sb.Append(" \n");
                }
            }
            SaveButtonToolTip = sb.ToString();
        }
    }
}
