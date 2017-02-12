using GerenciadorMongo.Apresentacao.ViewModels.Pedidos;
using System.Windows.Controls;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Interação lógica para VendaListagem.xam
    /// </summary>
    public partial class PedidoListagem : UserControl
    {
        public PedidoListagem(PedidosViewModelList viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
