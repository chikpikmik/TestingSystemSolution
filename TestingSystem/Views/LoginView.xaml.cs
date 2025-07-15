
using System.Windows;
using System.Windows.Controls;
using TestingSystem.ViewModels;

namespace TestingSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView(LoginVM loginVM)
        {
            InitializeComponent();
            DataContext = loginVM;
        }

    }

    
}
