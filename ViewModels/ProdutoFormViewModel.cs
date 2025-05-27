using PDVApp.Data;
using PDVApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PDVApp.ViewModels
{
    public class ProdutoFormViewModel : INotifyPropertyChanged
    {

        public ICommand SalvarCommand { get; }

        private readonly PDVContext _context;

        public ProdutoFormViewModel(PDVContext context)
        {
            _context = context;
            SalvarCommand = new RelayCommand(Salvar);
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set { _nome = value; OnPropertyChanged(); }
        }

        private string _preco;
        public string Preco
        {
            get => _preco;
            set { _preco = value; OnPropertyChanged(); }
        }

        private string _estoque;
        public string Estoque
        {
            get => _estoque;
            set { _estoque = value; OnPropertyChanged(); }
        }

        

        private void Salvar()
        {
            if (string.IsNullOrWhiteSpace(Nome) ||
                !decimal.TryParse(Preco, out var precoDecimal) ||
                !int.TryParse(Estoque, out var estoqueInt))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                return;
            }

            var produto = new Produto
            {
                Nome = Nome,
                Preco = precoDecimal,
                Estoque = estoqueInt
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            MessageBox.Show("Produto salvo com sucesso!");
            // Aqui pode-se fechar a janela, ou sinalizar sucesso
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
