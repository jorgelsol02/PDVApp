using PDVApp.Data;
using PDVApp.ViewModels;
using System.Windows;

namespace PDVApp.Views
{
    public partial class ProdutoFormView : Window
    {
        public ProdutoFormView(PDVContext context)
        {
            InitializeComponent();
            DataContext = new ProdutoFormViewModel(context);
        }
    }
}
