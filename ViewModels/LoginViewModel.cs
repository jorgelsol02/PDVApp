using System.ComponentModel;
using System.Windows.Input;

namespace PDVApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
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
            // Aqui será a lógica de autenticação (ex: consulta ao banco)
            if (Login == "admin" && Senha == "123")
            {
                System.Windows.MessageBox.Show("Login bem-sucedido!");
            }
            else
            {
                System.Windows.MessageBox.Show("Usuário ou senha incorretos.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
}
