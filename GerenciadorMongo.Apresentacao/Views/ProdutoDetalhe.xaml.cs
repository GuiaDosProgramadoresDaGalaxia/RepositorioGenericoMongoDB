using GerenciadorMongo.Apresentacao.ViewModels.Produtos;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Lógica interna para ProdutoDetalhe.xaml
    /// </summary>
    public partial class ProdutoDetalhe : Window
    {
        public ProdutoDetalhe(ProdutoViewModelDetail viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
