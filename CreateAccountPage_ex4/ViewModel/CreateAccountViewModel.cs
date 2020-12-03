using CreateAccountPage_ex4.Model;
using CreateAccountPage_ex4.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CreateAccountPage_ex4.ViewModel
{
    public class CreateAccountViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string userName;
        public string UserName 
        {
            get { return userName;}
            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string passwordConfirm;
        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set
            {
                passwordConfirm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordConfirm"));
            }
        }
        private string alertContent = string.Empty;
        public string AlertContent
        {
            get { return alertContent; }
            set
            {
                alertContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlertContent"));
            }
        }
        private bool turnAlertLabel =false;
        public bool TurnAlertLabel
        {
            get { return turnAlertLabel; }
            set
            {
                turnAlertLabel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnAlertLabel"));
            }
        }
        public Command cmdCreateAccount { get; set; }

        ICreateAccountService ICA = DependencyService.Get<ICreateAccountService>();
        public CreateAccountViewModel()
        {
            cmdCreateAccount = new Command(CreateAccount);
        }

        private async void CreateAccount(object obj)
        {
            UserModel user = new UserModel()
            {
                userName = UserName,
                firstName = FirstName,
                lasttName = LastName,
                email = Email,
                password = Password,
                passwordConfirm = PasswordConfirm
            };

            // Todo : validations

            bool result = await ICA.CreateAccount(user);

            if(result)
            {
                TurnAlertLabel = true;
                AlertContent = "Your account is created";
            }
            else
            {
                TurnAlertLabel = true;
                AlertContent = "Cannot create your new account.";
            }
        }
    }
}
