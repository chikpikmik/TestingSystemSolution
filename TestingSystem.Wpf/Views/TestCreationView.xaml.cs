
using System.Windows.Controls;
using TestingSystem.Wpf.ViewModels;

namespace TestingSystem.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    public partial class TestCreationView : Page
    {
        public TestCreationView(TestCreationViewModel testCreationViewModel)
        {
            InitializeComponent();
            DataContext = testCreationViewModel;
        }
    }
}
