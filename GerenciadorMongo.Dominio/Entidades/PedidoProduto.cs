namespace GerenciadorMongo.Dominio.Entidades
{
    public class PedidoProduto
    {
        public int Quantidade { get; set; }
        public int Total { get; set; }
        public Produto Produto { get; set; }
    }
}
