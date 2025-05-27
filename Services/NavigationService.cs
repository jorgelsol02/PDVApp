using System.Windows;

namespace PDVApp.Services
{
    public class NavigationService : INavigationService
    {
        public void NavegarPara<T>() where T : Window, new()
        {
            var window = new T();
            window.Show();

            // Fecha a janela atual (opcional, dependendo do fluxo)
            Application.Current.Windows[0]?.Close();
        }
    }
}
