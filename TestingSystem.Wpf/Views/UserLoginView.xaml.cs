
using System.Windows;
using System.Windows.Controls;
using TestingSystem.Wpf.ViewModels;
using TestingSystem.Wpf.ViewModels;

namespace TestingSystem.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class UserLoginView : Page
    {
        public UserLoginView(UserLoginViewModel userLoginViewModel)
        {
            InitializeComponent();
            DataContext = userLoginViewModel;
        }

    }

    
}
