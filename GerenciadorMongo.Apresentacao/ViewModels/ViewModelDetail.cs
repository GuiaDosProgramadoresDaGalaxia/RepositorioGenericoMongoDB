using GerenciadorMongo.Apresentacao.Models;
using GerenciadorMongo.Apresentacao.Uteis;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.ViewModels
{
    public abstract class ViewModelDetail<TModel> : ViewModelBase where TModel : Model
    {
        public TModel Model { get; set; }

        public Janelas Janela { get; set; }

        public Command<Window> ConfirmarCommand { get; set; }
        public Command<Window> CancelarCommand { get; set; }

        public ViewModelDetail(TModel model, Janelas janela)
        {
            Model = model;
            Janela = janela;

            ConfirmarCommand = new Command<Window>(Confirmar);
            CancelarCommand = new Command<Window>(Cancelar);
        }

        protected virtual void Confirmar(Window e)
        {
            e.DialogResult = true;
            e.Close();
        }

        protected virtual void Cancelar(Window e)
        {
            var dialog = MessageBox.Show("Tem certeza que dejesa cancelar?", "Cancelar?", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if(dialog == MessageBoxResult.OK)
                e.DialogResult = false;
        }
    }
}
