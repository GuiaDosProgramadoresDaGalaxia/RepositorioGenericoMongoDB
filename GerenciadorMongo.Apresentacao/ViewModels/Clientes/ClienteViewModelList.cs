using AutoMapper;
using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Apresentacao.Views;
using GerenciadorMongo.Dominio.Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GerenciadorMongo.Apresentacao.ViewModels.Clientes
{
    public class ClienteViewModelList : ViewModelList<ClienteModel>
    {
        public ClienteViewModelList()
        {
            Models = new ObservableCollection<ClienteModel>(Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(repositorio.ObterTodos<Cliente>()));
        }
        protected override void Adicionar()
        {
            ClienteViewModelDetail viewModel = new ClienteViewModelDetail(new ClienteModel(), Janelas.Adicionar);
            ClienteDetalhe view = new ClienteDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
                Models.Add(viewModel.Model);
        }

        protected override void Editar(ClienteModel model)
        {
            var temporario = Mapper.Map<ClienteModel>(model);
            ClienteViewModelDetail viewModel = new ClienteViewModelDetail(temporario, Janelas.Editar);
            ClienteDetalhe view = new ClienteDetalhe(viewModel);

            view.ShowDialog();
            if (view.DialogResult.HasValue && view.DialogResult.Value)
                Mapper.Map(temporario, model);
        }

        protected override void Deletar(ClienteModel model)
        {
            repositorio.Deletar<Cliente>(model.Id);
        }
    }
}
