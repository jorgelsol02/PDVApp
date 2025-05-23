using System.Windows;
using PDVApp.Views;

namespace PDVApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var login = new LoginView();
            login.Show();
        }
    }
}
