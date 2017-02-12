using BibliotecaSubeta.Mongo.Repositorio;
using GerenciadorMongo.Data;

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
