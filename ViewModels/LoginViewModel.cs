using PDVApp.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PDVApp.ViewModels
{

    public class LoginViewModel : INotifyPropertyChanged
    {

        public event Action LoginSucesso;

        private readonly PDVContext _context;

        public LoginViewModel(PDVContext context)
        {
            _context = context;
            EntrarCommand = new RelayCommand(ExecutarLogin);
        }


        private string _login;
        private string _senha;

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

        public ICommand EntrarCommand { get; }

        public LoginViewModel() => EntrarCommand = new RelayCommand(ExecutarLogin);

        private void ExecutarLogin(object parametro)
        {

            var usuario = _context.Usuarios
             .FirstOrDefault(u => u.Login == Login && u.Senha == Senha);

            if (usuario != null)
            {
                MessageBox.Show("Login bem-sucedido!");
                LoginSucesso?.Invoke();
            }

            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
}