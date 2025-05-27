using System.Windows;

namespace PDVApp.Services
{
    public interface INavigationService
    {
        void NavegarPara<T>() where T : Window, new();
    }
}
