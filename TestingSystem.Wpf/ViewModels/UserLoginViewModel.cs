
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Services;
using TestingSystem.Wpf.Utils;

namespace TestingSystem.Wpf.ViewModels
{
    public class UserLoginViewModel : ViewModelBase
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        //private bool _rememberMe;

        //[Required]
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        
        //[Required]
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        //public bool RememberMe
        //{
        //    get => _rememberMe;
        //    set => SetField(ref _rememberMe, value);
        //}


        // Сервисы
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        private readonly ISessionManager _sessionManager;

        // Команды
        public ICommand LoginCommand { get; }
        //public ICommand ForgotPasswordCommand { get; }
        //public ICommand NavigateToRegisterViewCommand { get; }

        public UserLoginViewModel(INavigationService navigationService, IUserService userService, ISessionManager sessionManager)
        {
            _navigationService = navigationService;
            _userService = userService;
            _sessionManager = sessionManager;

            //NavigateToRegisterViewCommand = new RelayCommand(
            //    () => _navigationService.NavigateToRegisterView());

            LoginCommand = new AsyncRelayCommand(ExecuteLoginAsync);
        }
        private async Task ExecuteLoginAsync()
        {
            try
            {
                var user = await _userService.Authenticate(new UserLoginDto{ 
                    Login = this.Login,
                    Password = this.Password 
                });

                if (user != null)
                {
                    MessageBox.Show($"Добро пожаловать, {user.Name}");
                    //_navigationService.NavigateToLoginView();
                }
                else
                    MessageBox.Show("Неверный логин или пароль");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

    }

}
