using PDVApp.Data;
using PDVApp.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using PDVApp.Views;

namespace PDVApp.ViewModels
{
  
public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }

        public event Action LoginSucesso = delegate { }; // Initialize with an empty delegate to avoid nullability issues.

        private readonly PDVContext _context;

        private readonly INavigationService _navigation;

        private string _login = string.Empty; // Initialize with an empty string to avoid nullability issues.
        private string _senha = string.Empty; // Initialize with an empty string to avoid nullability issues.

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(nameof(Login)); }
        }

        public string Senha
        {
            get => _senha;
            set { _senha = value; OnPropertyChanged(nameof(Senha)); }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { }; // Initialize with an empty delegate to avoid nullability issues.

        public LoginViewModel(PDVContext context, INavigationService navigation)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            LoginCommand = new RelayCommand(ExecutarLogin);
        }

        private void ExecutarLogin()
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Login == Login && u.Senha == Senha);

            if (usuario != null)
            {
                _navigation.NavegarPara<ProdutoView>(fecharJanelaAtual:false);
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }

        protected void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
}