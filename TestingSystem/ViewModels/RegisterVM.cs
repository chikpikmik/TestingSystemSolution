
using System.Windows;
using System.Windows.Input;
using TestingSystem.Core.Services;
using TestingSystem.Utils;

namespace TestingSystem.ViewModels
{
    public class RegisterVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        public ICommand NavigateToLoginViewCommand { get; }


        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

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

        private string _passwordCheck;
        public string PasswordCheck
        {
            get => _passwordCheck;
            set => SetProperty(ref _passwordCheck, value);
        }

        // Image
        public ICommand RegisterCommand { get; set; }

        public RegisterVM(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;

            NavigateToLoginViewCommand = new RelayCommand(
            () => _navigationService.NavigateToLoginView());

            RegisterCommand = new AsyncRelayCommand(ExecuteRegisterAsync);
        }
        private async Task ExecuteRegisterAsync()
        {
            if (Password != PasswordCheck) {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            try {
                await _userService.Register(Name, Login, Password);
                MessageBox.Show("Регистрация успешна");
                _navigationService.NavigateToLoginView();
            }
            catch (Exception ex) {
                // logger.LogError(ex, "Ошибка при регистрации пользователя");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


    }
}
