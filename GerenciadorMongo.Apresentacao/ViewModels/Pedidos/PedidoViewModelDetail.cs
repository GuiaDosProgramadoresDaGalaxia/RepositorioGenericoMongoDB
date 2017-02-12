using AutoMapper;
using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.ViewModels.Pedidos
{
    public class PedidoViewModelDetail : ViewModelDetail<PedidoModel>
    {
        private int index;

        private PedidoProdutoModel produto;

        public PedidoProdutoModel Produto
        {
            get { return produto; }
            set
            {
                produto = value;

                if (value.Produto != null)
                    produto.Produto = Produtos.Find(c => c.Id == value.Produto.Id);

                OnPropertyChanged("Produto");
            }
        }

        public Command AdicionarCommand { get; set; }
        public Command<PedidoProdutoModel> RemoverCommand { get; set; }

        public List<ClienteModel> Clientes { get; set; }
        public List<ProdutoModel> Produtos { get; set; }

        public PedidoViewModelDetail(PedidoModel model, Janelas janela, int _index) : base(model, janela)
        {
            index = _index;
            Clientes = new List<ClienteModel>(Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(repositorio.ObterTodos<Cliente>()));
            Produtos = new List<ProdutoModel>(Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(repositorio.ObterTodos<Produto>()));

            AdicionarCommand = new Command(Adicionar);
            RemoverCommand = new Command<PedidoProdutoModel>(Remover);

            Produto = new PedidoProdutoModel();

            if (Janela == Janelas.Editar)
            {
                Model.Cliente = Clientes.Find(c => c.Id == model.Cliente.Id);
            }   
            else
            {
                Model.Numero = index;
            }            
        }

        protected void Remover(PedidoProdutoModel model)
        {
            Model.Produtos.Remove(model);
            Model.CalcularTotal();
        }

        protected void Adicionar()
        {
            Model.Produtos.Add(Produto);
            Model.CalcularTotal();
            Produto = new PedidoProdutoModel();
        }

        protected override void Confirmar(Window e)
        {
            var pedido = Mapper.Map<PedidoModel, Pedido>(Model);

            var dominio = Mapper.Map<ClienteModel, Cliente>(Model.Cliente);

            if (Janela == Janelas.Adicionar)
                dominio.Pedidos.Add(pedido);
            else
            {
                var editar = dominio.Pedidos.Single(c => c.Numero == pedido.Numero);
                dominio.Pedidos.Remove(editar);
                dominio.Pedidos.Add(pedido);
            }
                

            repositorio.Atualizar(dominio, "Subeta");

            base.Confirmar(e);
        }
    }
}
