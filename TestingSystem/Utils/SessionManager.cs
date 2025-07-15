using TestingSystem.Core.Models;

namespace TestingSystem.Core.Utils
{
    public interface ISessionManager
    {
        User CurrentUser { get; set; }
        bool IsLoggedIn { get; }
        void Logout();
    }

    public class SessionManager : ISessionManager
    {
        private User _currentUser;

        public User CurrentUser
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