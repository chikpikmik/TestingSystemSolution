
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TestingSystem.Core.Repositories;
using TestingSystem.Core.Services;
using TestingSystem.Core.Utils;
using TestingSystem.Data.Sqlite;
using TestingSystem.Data.Sqlite.Mappings;
using TestingSystem.Data.Sqlite.Repositories;
using TestingSystem.Wpf.Utils;
using TestingSystem.Wpf.ViewModels;
using TestingSystem.Wpf.Views;

namespace TestingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем ViewModel's
            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<UserLoginViewModel>();
            services.AddSingleton<UserRegisterViewModel>();
            services.AddSingleton<TestCreationViewModel>();

            // Регистрируем Views
            services.AddTransient<MainWindow>();
            services.AddTransient<UserLoginView>();
            services.AddTransient<UserRegisterView>();
            services.AddTransient<TestCreationView>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISessionManager, SessionManager>();

            // Регистрируем DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={AppDbContext.GetDatabasePath()}"),
                ServiceLifetime.Scoped);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IPasswordHasher, Sha256PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITestRepository, TestRepository>();

            services.AddAutoMapper(typeof(EntityDtoMappingProfile));

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаём базу данных при старте (если её нет)
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            // Получаем MainWindow через DI и показываем его
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

    }

}
