using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace TestingSystem.Utils
{
    public interface INavigationService
    {
        void NavigateToLoginView();
        void NavigateToRegisterView();

        event Action RequestNavigateToLoginView;
        event Action RequestNavigateToRegisterView;
    }

    public class NavigationService : INavigationService
    {
        public event Action RequestNavigateToLoginView;
        public event Action RequestNavigateToRegisterView;

        public void NavigateToLoginView() => RequestNavigateToLoginView?.Invoke();
        public void NavigateToRegisterView() => RequestNavigateToRegisterView?.Invoke();
    }
}
