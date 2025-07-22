
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using System.Windows.Input;
using TestingSystem.Wpf.Utils;

using TestingSystem.Wpf.Views;

namespace TestingSystem.Wpf
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
        public ICommand NavigateToCreateTestViewCommand { get; }

        public MainWindowVM(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;

            // Подписываемся на события навигации
            navigationService.RequestNavigateToLoginView += NavigateToLoginView;
            navigationService.RequestNavigateToRegisterView += NavigateToRegisterView;
            navigationService.RequestNavigateToCreateTestView += NavigateToCreateTestView;

            // Инициализация начальной View
            CurrentView = _serviceProvider.GetRequiredService<TestCreationView>();

            // Создание команд навигации
            NavigateToLoginViewCommand = new RelayCommand(NavigateToLoginView);
            NavigateToRegisterViewCommand = new RelayCommand(NavigateToRegisterView);
            NavigateToCreateTestViewCommand = new RelayCommand(NavigateToCreateTestView);
        }

        public void NavigateToLoginView()
        {
            CurrentView = _serviceProvider.GetRequiredService<UserLoginView>();
        }

        public void NavigateToRegisterView()
        {
            CurrentView = _serviceProvider.GetRequiredService<UserRegisterView>();
        }

        public void NavigateToCreateTestView()
        {
            CurrentView = _serviceProvider.GetRequiredService<TestCreationView>();
        }

    }
}
