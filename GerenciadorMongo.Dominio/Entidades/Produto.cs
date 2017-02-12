namespace GerenciadorMongo.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return "Produtos";
        }
    }
}