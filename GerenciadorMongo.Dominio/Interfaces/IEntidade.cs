using MongoDB.Bson;
using System;

namespace GerenciadorMongo.Dominio.Interfaces
{
    public interface IEntidade
    {
        ObjectId Id { get; set; }
        bool Ativo { get; set; }
        DateTime DataCriacao { get; set; }
        DateTime? DataModificacao { get; set; }
        string CriadoPor { get; set; }
        string ModificadoPor { get; set; }
    }
}
