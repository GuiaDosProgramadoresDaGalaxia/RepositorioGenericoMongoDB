using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using System.Collections.ObjectModel;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.ViewModels
{
    public abstract class ViewModelList<TModel> : ViewModelBase where TModel : Model
    {
        public ObservableCollection<TModel> Models { get; set; }

        public Command AdicionarCommand { get; set; }
        public Command<TModel> EditarCommand { get; set; }
        public Command<TModel> RemoverCommand { get; set; }

        public ViewModelList()
        {
            AdicionarCommand = new Command(Adicionar);
            EditarCommand = new Command<TModel>(Editar);
            RemoverCommand = new Command<TModel>(Remover);
        }

        protected abstract void Adicionar();

        protected abstract void Editar(TModel model);

        protected virtual void Remover(TModel model)
        {
            var dialog = MessageBox.Show("Tem certeza que dejesa excluir?", "Excluir", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (dialog == MessageBoxResult.OK)
            {
                Models.Remove(model);
                Deletar(model);
            }
        }

        protected abstract void Deletar(TModel model);
    }
}
