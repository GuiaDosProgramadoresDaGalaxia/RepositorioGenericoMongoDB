using GerenciadorMongo.Dominio.Interfaces;
using GerenciadorMongo.Servicos;
using System.ComponentModel;

namespace GerenciadorMongo.Apresentacao.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly IRepositorio repositorio;

        public ViewModelBase()
        {
            repositorio = Servico.ObterRepositorio();
        }

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
