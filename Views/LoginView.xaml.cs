using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using PDVApp.Data;
using PDVApp.ViewModels;

namespace PDVApp.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            var context = App.AppHost.Services.GetService<PDVContext>();
            var vm = new LoginViewModel(context);
            this.DataContext = vm;
            vm.LoginSucesso += () =>
            {
                var mainWindow = new ProdutoView();
                mainWindow.Show();
                this.Close();
            };
        }

        private void SenhaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Senha = ((PasswordBox)sender).Password;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
