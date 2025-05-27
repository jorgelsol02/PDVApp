using System.Windows;

namespace PDVApp.Services
{
    public interface INavigationService
    {
        void NavegarPara<T>(object parametro = null, bool fecharJanelaAtual = false) where T : Window;
    }

}
