using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PDVApp.Data;
using PDVApp.Views;

namespace PDVApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProdutoView : Window
    {

        public PDVContext _context;

        public ProdutoView()
        {
            InitializeComponent();
            _context = App.AppHost.Services.GetService<PDVContext>();
            btnProdutos.Click += BtnProdutos_Click;
            btnIncluirProduto.Click += BtnIncluirProduto_Click;
        }

        private void BtnProdutos_Click(object sender, RoutedEventArgs e)
        {
            var produtos = _context.Produtos.ToList();
            ProductsList.ItemsSource = produtos;
        }

        private void BtnIncluirProduto_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProdutoFormView(_context) { Owner = this };
            if (form.ShowDialog() == true)
            {
                ProductsList.ItemsSource = _context.Produtos.ToList();
            }
        }
    }
}