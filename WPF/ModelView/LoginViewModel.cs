using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BusinessLogic;


namespace WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(
                    param => Cancel(),
                    param => true
                ));
            }
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(
                    param => Login(),
                    param => CanLogin()
                ));
            }
        }

        private void Cancel()
        {
            // Add cancel logic if needed
            MessageBox.Show("Login canceled!");
        }

        private void Login()
        {
            // Add login logic here
            if (CanLogin())
            {
                // In a real-world scenario, you should retrieve the hashed password and salt from the database
                string storedHashedPassword = "HashedPasswordFromDatabase"; // Replace with the actual hashed password from the database
                string storedSalt = "SaltFromDatabase"; // Replace with the actual salt from the database

                // Hash the entered password with the stored salt
                string enteredPasswordHash = HashPassword(Password, storedSalt);

                // Compare the hashed passwords
                if (storedHashedPassword == enteredPasswordHash)
                {
                    MessageBox.Show($"Logged in as {Username}");
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private bool CanLogin()
        {
            // Add validation logic here
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        // Utility method to hash the password using SHA-256 with a salt
        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashedPasswordBytes);
            }
        }
    }
}
