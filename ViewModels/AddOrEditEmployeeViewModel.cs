using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagementSystem.ViewModels
{
    public class AddOrEditEmployeeViewModel : ViewModelBase
    {
        private ObservableCollection<PhoneNumber> _phoneNumbers;
        public IEnumerable<PhoneNumber> PhoneNumbers => _phoneNumbers;

        private ObservableCollection<Email> _emails;
        public IEnumerable<Email> Emails => _emails;

        private readonly List<PhoneNumber> _addedPhoneNumbers;
        private readonly List<PhoneNumber> _removedPhoneNumbers;
        private readonly List<Email> _addedEmails;
        private readonly List<Email> _removedEmails;


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
                OnPropertyChanged(nameof(PhoneNumberDescription));
            }
        }


        public ICommand SaveEmployeeCommand { get; }
        public ICommand CancelCommand { get; } 
        public ICommand AddPhoneNumberCommand { get; }
        public ICommand RemovePhoneNumberCommand { get; }
        public ICommand AddEmailCommand { get; }
        public ICommand RemoveEmailCommand { get; }



        public AddOrEditEmployeeViewModel(EmployerBriefcase employerBriefcase, NavigationStore navigationStore, Func<EmployeeListingViewModel> createEmployeeListingViewModel)
        {
            _phoneNumbers = new ObservableCollection<PhoneNumber>();
            _addedPhoneNumbers = new List<PhoneNumber>();
            _removedPhoneNumbers = new List<PhoneNumber>();
            _emails = new ObservableCollection<Email>();
            _addedEmails = new List<Email>();
            _removedEmails = new List<Email>();

            SaveEmployeeCommand = new AddOrEditEmployeeCommand(this, employerBriefcase);
            CancelCommand = new NavigateCommand(navigationStore, createEmployeeListingViewModel);
            AddPhoneNumberCommand = new RelayCommand(AddPhoneNumber);
            RemovePhoneNumberCommand = new RelayCommand(RemovePhoneNumber);
            AddEmailCommand = new RelayCommand(AddEmail);
            RemoveEmailCommand = new RelayCommand(RemoveEmail);

            FillView();
        }

        private void FillView()
        {
            PageTitle = "Add Employee";
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
            _addedPhoneNumbers.Add(ph);

            PhoneNumber = "";
            PhoneNumberDescription = "";
        }

        private void RemovePhoneNumber()
        {
           if(SelectedPhoneNumber != null)
           {
                if (!_addedPhoneNumbers.Remove(SelectedPhoneNumber))
                {
                    _removedPhoneNumbers.Add(SelectedPhoneNumber);
                }
                _phoneNumbers.Remove(SelectedPhoneNumber);
           }
        }

        private void AddEmail()
        {
            Email email = new Email(0, Email, EmailDescription);

            _emails.Add(email);
            _addedEmails.Add(email);

            Email = "";
            EmailDescription = "";
        }

        private void RemoveEmail()
        {
            if(SelectedEmail != null)
            {
                if (!_addedEmails.Remove(SelectedEmail))
                {
                    _removedEmails.Add(SelectedEmail);
                }
                _emails.Remove(SelectedEmail);
            }
        }
    }
}
