using AutoMapper;
using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Apresentacao.Views;
using GerenciadorMongo.Dominio.Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GerenciadorMongo.Apresentacao.ViewModels.Pedidos
{
    public class PedidosViewModelList : ViewModelList<PedidoModel>
    {
        private int index;
        public PedidosViewModelList()
        {
            var pedidos = repositorio.ObterTodos<Cliente>().SelectMany(c => c.Pedidos,
                (parent, child) =>
                new PedidoModel
                {
                    Numero = child.Numero,
                    Total = child.Total,
                    Produtos = Mapper.Map<List<PedidoProduto>, ObservableCollection<PedidoProdutoModel>>(child.Produtos.ToList()),
                    Cliente = Mapper.Map<Cliente, ClienteModel>(parent)            
                });

            index = pedidos.Count() + 1;

            Models = new ObservableCollection<PedidoModel>(pedidos);
        }
        protected override void Adicionar()
        {
            PedidoViewModelDetail viewModel = new PedidoViewModelDetail(new PedidoModel(), Janelas.Adicionar, index);
            PedidoDetalhe view = new PedidoDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
            {
                Models.Add(viewModel.Model);
                index++;
            }               
        }

        protected override void Deletar(PedidoModel model)
        {
            var cliente = repositorio.Obter<Cliente>(c => c.Id == model.Cliente.Id);
            cliente.Pedidos.Remove(cliente.Pedidos.Single(c => c.Numero == model.Numero));
            repositorio.Atualizar(cliente, "Subeta");
        }

        protected override void Editar(PedidoModel model)
        {
            var temporario = Mapper.Map<PedidoModel>(model);
            PedidoViewModelDetail viewModel = new PedidoViewModelDetail(temporario, Janelas.Editar, index);
            PedidoDetalhe view = new PedidoDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
                Mapper.Map(temporario, model);
        }
    }
}
