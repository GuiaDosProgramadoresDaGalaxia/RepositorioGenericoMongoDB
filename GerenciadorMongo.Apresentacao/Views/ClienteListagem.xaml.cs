using GerenciadorMongo.Apresentacao.ViewModels.Clientes;
using System.Windows.Controls;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Interação lógica para ClienteListagem.xam
    /// </summary>
    public partial class ClienteListagem : UserControl
    {
        public ClienteListagem(ClienteViewModelList viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
