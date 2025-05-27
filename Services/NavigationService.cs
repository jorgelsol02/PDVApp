using PDVApp.Data;
using PDVApp.Views;
using System.Linq;
using System.Windows;

namespace PDVApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly PDVContext _context;

        public NavigationService(PDVContext context)
        {
            _context = context;
        }

        public void NavegarPara<T>(object parametro = null, bool fecharJanelaAtual = false) where T : Window
        {
            Window novaJanela;

            if (typeof(T) == typeof(ProdutoView))
                novaJanela = new ProdutoView(_context, this);
            else if (typeof(T) == typeof(LoginView))
                novaJanela = new LoginView(_context, this);
            else if (typeof(T) == typeof(ProdutoFormView))
                novaJanela = new ProdutoFormView(_context);
            else
                throw new InvalidOperationException($"Tipo de janela não suportado: {typeof(T)}");

            if (parametro != null && novaJanela.DataContext != null)
            {
                var prop = novaJanela.DataContext.GetType().GetProperty("Parametro");
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(novaJanela.DataContext, parametro);
                }
            }

            novaJanela.Show();

            if (fecharJanelaAtual)
            {
                Application.Current.Windows
                    .OfType<Window>()
                    .FirstOrDefault(w => w.IsActive)?.Close();
            }
        }
    }
}
