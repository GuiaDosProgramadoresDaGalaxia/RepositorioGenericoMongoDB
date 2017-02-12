using AutoMapper;
using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using GerenciadorMongo.Dominio.Entidades;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.ViewModels.Clientes
{
    public class ClienteViewModelDetail : ViewModelDetail<ClienteModel>
    {
        public ClienteViewModelDetail(ClienteModel model, Janelas janela) : base(model, janela)
        {
        }

        protected override void Confirmar(Window e)
        {
            var dominio = Mapper.Map<ClienteModel, Cliente>(Model);

            if (Janela == Janelas.Adicionar)
                repositorio.Criar(dominio, "Subeta");
            else
                repositorio.Atualizar(dominio, "Subeta");

            base.Confirmar(e);
        }
    }
}
