
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using TestingSystem.Core.Models;
using TestingSystem.Core.Services;
using TestingSystem.Utils;
using TestingSystem.Views;

namespace TestingSystem.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        public ICommand NavigateToRegisterViewCommand { get; }
        public ICommand LoginCommand { get; }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public LoginVM(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;

            NavigateToRegisterViewCommand = new RelayCommand(
                () => _navigationService.NavigateToRegisterView());

            LoginCommand = new AsyncRelayCommand(ExecuteLoginAsync);

        }
        private async Task ExecuteLoginAsync()
        {
            try
            {
                var user = await _userService.Authenticate(Login, Password);
                if (user != null)
                    MessageBox.Show($"Добро пожаловать, {user.Name}");
                else
                    MessageBox.Show("Неверный логин или пароль");

                //_navigationService.NavigateToLoginView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }



}
