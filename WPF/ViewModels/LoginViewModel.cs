using BusinessLogic.IBL;
using System;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Commands;
using WPF.Interfaces;
using WPF.Utilities;

namespace WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged, ICloseable
    {
        private readonly IUserBL userBL;
        private string userId;
        private string userName;
        public Action LoginFailed { get; set; }
        public Action LoginSuccessful { get; set; }

        public LoginViewModel(IUserBL userBL)
        {
            this.userBL = userBL;
            LoginCommand = new LoginCommand(this);
            CancelCommand = new CancelCommand(this);
        }

        public bool Login()
        {
            var userId = userBL.AuthUser(Username, Password);
            if (userId != 0) 
            {
                UserContext.UserId = userId;
                return true;
            }
            else
            { return false; }
        }

        public string Username
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }

        public string Password
        {
            private get;
            set;
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ICloseable
        public Action Close { get; set; }
        #endregion
    }
}
