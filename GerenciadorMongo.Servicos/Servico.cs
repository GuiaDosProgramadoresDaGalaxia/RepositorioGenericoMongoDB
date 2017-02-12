using GerenciadorMongo.Data.Contexto;
using GerenciadorMongo.Data.Repositorio;
using GerenciadorMongo.Dominio.Interfaces;

namespace GerenciadorMongo.Servicos
{
    public static class Servico
    {
        public static IRepositorio ObterRepositorio()
        {
            return new Repositorio<GerenciadorMongoContexto>(new GerenciadorMongoContexto());
        }
    }
}
