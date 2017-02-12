using GerenciadorMongo.Dominio.Uteis;

namespace GerenciadorMongo.Dominio.Entidades
{
    [Colecao("Produtos")]
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}