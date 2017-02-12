using GerenciadorMongo.Apresentacao.ViewModels.Clientes;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Lógica interna para ClienteDetalhe.xaml
    /// </summary>
    public partial class ClienteDetalhe : Window
    {
        public ClienteDetalhe(ClienteViewModelDetail viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
