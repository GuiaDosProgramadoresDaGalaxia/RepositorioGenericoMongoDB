using GerenciadorMongo.Dominio.Entidades;
using GerenciadorMongo.Dominio.Interfaces;
using GerenciadorMongo.Dominio.Uteis;
using MongoDB.Driver;
using System;
using System.Configuration;

namespace GerenciadorMongo.Data.Contexto
{
    public class GerenciadorMongoContexto : IContexto
    {
        private readonly IMongoDatabase database;

        public IMongoDatabase DataBase { get { return database; } }

        public IMongoCollection<Cliente> Clientes { get { return database.GetCollection<Cliente>("Clientes"); } }
        public IMongoCollection<Produto> Produtos { get { return database.GetCollection<Produto>("Produtos"); } }

        public GerenciadorMongoContexto()
        {
            var cliente = new MongoClient(ConfigurationManager.ConnectionStrings["GerenciadorMongoContexto"].ConnectionString);
            database = cliente.GetDatabase("GerenciadorMongo");
        }

        public IMongoCollection<TEntidade> Set<TEntidade>(TEntidade entidade) where TEntidade : class, IEntidade
        {
            return database.GetCollection<TEntidade>(entidade.ToString());
        }

        public IMongoCollection<TEntidade> Set<TEntidade>() where TEntidade : class, IEntidade, new()
        {
            var entidadeTipo = typeof(TEntidade);
            var atributo = Attribute.GetCustomAttribute(entidadeTipo, typeof(ColecaoAttribute));
            var colecao = atributo as ColecaoAttribute;

            return database.GetCollection<TEntidade>(colecao.Nome);
        }
    }
}
