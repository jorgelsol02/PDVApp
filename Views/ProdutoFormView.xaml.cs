using PDVApp.Data;
using PDVApp.Models;
using System;
using System.Windows;

namespace PDVApp.Views
{
    public partial class ProdutoFormView : Window
    {
        private readonly PDVContext _context;

        public ProdutoFormView(PDVContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                !decimal.TryParse(txtPreco.Text, out var preco) ||
                !int.TryParse(txtEstoque.Text, out var estoque))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                return;
            }

            var produto = new Produto
            {
                Nome = txtNome.Text,
                Preco = preco,
                Estoque = estoque
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}
