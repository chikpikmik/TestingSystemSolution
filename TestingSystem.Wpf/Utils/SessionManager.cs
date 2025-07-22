using TestingSystem.Core.DTOs;

namespace TestingSystem.Wpf.Utils
{
    public interface ISessionManager
    {
        UserProfileDto CurrentUser { get; set; }
        bool IsLoggedIn { get; }
        void Logout();
    }

    public class SessionManager : ISessionManager
    {
        private UserProfileDto _currentUser;

        public UserProfileDto CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnSessionChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public void Logout()
        {
            CurrentUser = null;
            OnSessionChanged?.Invoke();
        }

        public event Action OnSessionChanged;
    }
}