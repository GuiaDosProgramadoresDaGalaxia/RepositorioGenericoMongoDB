using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Apresentacao.ViewModels.Clientes;
using GerenciadorMongo.Apresentacao.ViewModels.Pedidos;
using GerenciadorMongo.Apresentacao.ViewModels.Produtos;
using GerenciadorMongo.Apresentacao.Views;
using System.Windows.Controls;

namespace GerenciadorMongo.Apresentacao.ViewModels.Aplicacao
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Command ClienteCommand { get; set; }
        public Command ProdutoCommand { get; set; }
        public Command PedidoCommand { get; set; }

        private UserControl conteudo;

        public UserControl Conteudo
        {
            get { return conteudo; }
            set
            {
               conteudo = value;
                OnPropertyChanged("Conteudo");
            }
        }


        public MainWindowViewModel()
        {
            ClienteCommand = new Command(Clientes);
            ProdutoCommand = new Command(Produtos);
            PedidoCommand = new Command(Pedidos);
        }

        public void Clientes()
        {
            Conteudo = new ClienteListagem(new ClienteViewModelList());
        }

        public void Produtos()
        {
            Conteudo = new ProdutoListagem(new ProdutoViewModelList());
        }

        public void Pedidos()
        {
            Conteudo = new PedidoListagem(new PedidosViewModelList());
        }
    }
}
