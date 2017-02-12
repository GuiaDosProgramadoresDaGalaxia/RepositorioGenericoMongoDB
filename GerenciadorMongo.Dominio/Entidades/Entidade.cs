using GerenciadorMongo.Dominio.Interfaces;
using MongoDB.Bson;
using System;

namespace GerenciadorMongo.Dominio.Entidades
{
    public class Entidade : IEntidade
    {
        public bool Ativo { get; set; }

        public string CriadoPor { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public ObjectId Id { get; set; }

        public string ModificadoPor { get; set; }

        public Entidade()
        {
            Ativo = true;
        }
    }
}
