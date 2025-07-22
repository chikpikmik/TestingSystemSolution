
using System.Windows;
using System.Windows.Controls;
using TestingSystem.Wpf.ViewModels;

namespace TestingSystem.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class UserRegisterView : Page
    {
        public UserRegisterView(UserRegisterViewModel userRegisterViewModel)
        {
            InitializeComponent();
            DataContext = userRegisterViewModel;
        }
    }
}
