using PDVApp.Data;
using PDVApp.Services;
using PDVApp.ViewModels;
using System.Windows;

namespace PDVApp.Views
{
    public partial class ProdutoView : Window
        {

         public ProdutoView(PDVContext context, INavigationService navigation)
         {
               InitializeComponent();
               DataContext = new ProdutoViewModel(context, navigation);
         }
        }
    }