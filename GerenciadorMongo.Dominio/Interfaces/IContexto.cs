using MongoDB.Driver;

namespace GerenciadorMongo.Dominio.Interfaces
{
    public interface IContexto
    {
        IMongoDatabase DataBase { get; }
        IMongoCollection<TEntidade> Set<TEntidade>(TEntidade entidade) where TEntidade : class, IEntidade;
        IMongoCollection<TEntidade> Set<TEntidade>() where TEntidade : class, IEntidade, new();
    }
}
