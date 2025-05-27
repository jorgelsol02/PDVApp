using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using PDVApp.Data;
using PDVApp.Services;
using PDVApp.ViewModels;

namespace PDVApp.Views
{
    public partial class LoginView : Window
    {
        private PDVContext context;
        private NavigationService navigationService;

        public LoginView(PDVContext context, LoginViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public LoginView(PDVContext context, NavigationService navigationService)
        {
            this.context = context;
            this.navigationService = navigationService;
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
