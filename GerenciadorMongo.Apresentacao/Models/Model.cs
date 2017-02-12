using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace GerenciadorMongo.Apresentacao.Models
{
    public abstract class Model : INotifyPropertyChanged
    {
        public bool Ativo { get; set; }

        public string CriadoPor { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public ObjectId Id { get; set; }

        public string ModificadoPor { get; set; }

        public Model()
        {
            Ativo = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
