
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Services;
using TestingSystem.Wpf.Utils;

namespace TestingSystem.Wpf.ViewModels
{
    public class UserRegisterViewModel : ViewModelBase
    {
        private string _name = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _confirmPassword = string.Empty;

        //[Required(ErrorMessage = "Username is required")]
        //[MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        //[Required(ErrorMessage = "Login is required")]
        //[MinLength(3, ErrorMessage = "Login must be at least 3 characters")]
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        //[Required(ErrorMessage = "Password is required")]
        //[MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        //[CustomValidation(typeof(UserRegisterViewModel), nameof(ValidatePasswordConfirm))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public static ValidationResult? ValidatePasswordConfirm(string confirmPassword, ValidationContext context)
        {
            var vm = (UserRegisterViewModel)context.ObjectInstance;
            return vm.Password == confirmPassword
                ? ValidationResult.Success
                : new ValidationResult("Passwords do not match");
        }

        // Сервисы
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;

        // Команды
        public ICommand RegisterCommand { get; }
        //public ICommand NavigateToLoginViewCommand { get; }

        public UserRegisterViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;

            //NavigateToLoginViewCommand = new RelayCommand(
            //() => _navigationService.NavigateToLoginView());

            RegisterCommand = new AsyncRelayCommand(ExecuteRegisterAsync);
        }

        private async Task ExecuteRegisterAsync()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            try
            {
                await _userService.Register(new UserRegisterDto{
                    Name = this.Name, 
                    Login = this.Login, 
                    Password = this.Password
                });
                MessageBox.Show("Регистрация успешна");
                _navigationService.NavigateToLoginView();
            }
            catch (Exception ex)
            {
                // logger.LogError(ex, "Ошибка при регистрации пользователя");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }

}
