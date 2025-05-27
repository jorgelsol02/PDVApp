using PDVApp.Data;
using PDVApp.Models;
using PDVApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PDVApp.Views;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PDVApp.ViewModels
{
    public class ProdutoViewModel : INotifyPropertyChanged
    {
        public ICommand LoadProdutosCommand { get;}

        public ICommand IncluirProdutosCommand { get; }

        private readonly PDVContext _context;

        private readonly INavigationService _navigation;

        public ObservableCollection<Produto> Produtos { get; set; } = new();

        public ProdutoViewModel(PDVContext context, INavigationService navigation)
        {
            _context = context;
            _navigation = navigation;
            LoadProdutosCommand = new RelayCommand(LoadProdutos);
            IncluirProdutosCommand = new RelayCommand(FormProduto);

            LoadProdutos();
        }

        private void FormProduto()
        {
            var form = new ProdutoFormView(_context);
            var resultado = form.ShowDialog();
            if (resultado == true)
            {
                LoadProdutos(); // Recarrega produtos após inclusão
            }
        }   
        private void LoadProdutos()
        {
            Produtos.Clear();
            var produtos = _context.Produtos.ToList();
            foreach (var produto in produtos)
                Produtos.Add(produto);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
