using AutoMapper;
using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Apresentacao.Views;
using GerenciadorMongo.Dominio.Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GerenciadorMongo.Apresentacao.ViewModels.Produtos
{
    public class ProdutoViewModelList : ViewModelList<ProdutoModel>
    {
        public ProdutoViewModelList()
        {
            Models = new ObservableCollection<ProdutoModel>(Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(repositorio.ObterTodos<Produto>()));
        }

        protected override void Adicionar()
        {
            ProdutoViewModelDetail viewModel = new ProdutoViewModelDetail(new ProdutoModel(), Janelas.Adicionar);
            ProdutoDetalhe view = new ProdutoDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
                Models.Add(viewModel.Model);
        }

        protected override void Deletar(ProdutoModel model)
        {
            repositorio.Deletar<Produto>(model.Id);
        }

        protected override void Editar(ProdutoModel model)
        {
            var temporario = Mapper.Map<ProdutoModel>(model);
            ProdutoViewModelDetail viewModel = new ProdutoViewModelDetail(temporario, Janelas.Editar);
            ProdutoDetalhe view = new ProdutoDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
                Mapper.Map(temporario, model);
        }
    }
}
