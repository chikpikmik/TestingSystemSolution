
using System.Windows.Controls;
using TestingSystem.ViewModels;

namespace TestingSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    public partial class CreateTestView : Page
    {
        public CreateTestView(CreateTestVM createTestVM)
        {
            InitializeComponent();
            DataContext = createTestVM;
        }
    }
}
