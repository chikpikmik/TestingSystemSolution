using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace TestingSystem.Wpf.Utils
{
    public interface INavigationService
    {
        void NavigateToLoginView();
        void NavigateToRegisterView();
        void NavigateToCreateTestView();

        event Action RequestNavigateToLoginView;
        event Action RequestNavigateToRegisterView;
        event Action RequestNavigateToCreateTestView;
    }

    public class NavigationService : INavigationService
    {
        public event Action RequestNavigateToLoginView;
        public event Action RequestNavigateToRegisterView;
        public event Action RequestNavigateToCreateTestView;

        public void NavigateToLoginView() => RequestNavigateToLoginView?.Invoke();
        public void NavigateToRegisterView() => RequestNavigateToRegisterView?.Invoke();
        public void NavigateToCreateTestView() => RequestNavigateToCreateTestView?.Invoke();
    }
}
