
using System.Windows;
using System.Windows.Controls;
using TestingSystem.ViewModels;

namespace TestingSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView(RegisterVM registerVM)
        {
            InitializeComponent();
            DataContext = registerVM;
        }
    }
}
