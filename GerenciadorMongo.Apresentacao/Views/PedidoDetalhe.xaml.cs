using GerenciadorMongo.Apresentacao.ViewModels.Pedidos;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Lógica interna para VendaDetalhe.xaml
    /// </summary>
    public partial class PedidoDetalhe : Window
    {
        public PedidoDetalhe(PedidoViewModelDetail viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
