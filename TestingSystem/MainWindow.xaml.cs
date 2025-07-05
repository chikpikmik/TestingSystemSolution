using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TestingSystem.Data.Sqlite;
using TestingSystem.Utils;


namespace TestingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //using (var db = new AppDbContext())
            //{
            //    var imageEntity = db.Images.FirstOrDefault();
            //    myImageControl.Source = ImageConverter.ByteArrayToImageSource(imageEntity.Data);
            //}

        }
    }
}