using System.Collections.Generic;

namespace GerenciadorMongo.Dominio.Entidades
{
    public class Pedido
    {
        public int Numero { get; set; }
        public decimal Total { get; set; }

        public ICollection<PedidoProduto> Produtos { get; set; }

        public Pedido()
        {
            Produtos = new List<PedidoProduto>();
        }
    }
}