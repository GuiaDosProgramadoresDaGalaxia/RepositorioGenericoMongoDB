using GerenciadorMongo.Apresentacao.ViewModels.Produtos;
using System.Windows.Controls;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Interação lógica para ProdutoListagem.xam
    /// </summary>
    public partial class ProdutoListagem : UserControl
    {
        public ProdutoListagem(ProdutoViewModelList viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
