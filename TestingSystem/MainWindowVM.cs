
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;
using TestingSystem.Utils;
using TestingSystem.Views;

namespace TestingSystem
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;

        private Page _currentView;
        public Page CurrentView
        {
            get { return _currentView; }
            set { SetProperty(ref _currentView, value); }
        }

        public ICommand NavigateToLoginViewCommand { get; }
        public ICommand NavigateToRegisterViewCommand { get; }

        public MainWindowVM(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;

            // Подписываемся на события навигации
            navigationService.RequestNavigateToLoginView += NavigateToLoginView;
            navigationService.RequestNavigateToRegisterView += NavigateToRegisterView;

            // Инициализация начальной View
            CurrentView = _serviceProvider.GetRequiredService<LoginView>();

            // Создание команд навигации
            NavigateToLoginViewCommand = new RelayCommand(NavigateToLoginView);
            NavigateToRegisterViewCommand = new RelayCommand(NavigateToRegisterView);
        }

        public void NavigateToLoginView()
        {
            CurrentView = _serviceProvider.GetRequiredService<LoginView>();
        }

        public void NavigateToRegisterView()
        {
            CurrentView = _serviceProvider.GetRequiredService<RegisterView>();
        }

    }
}
