using System.Collections.Generic;

namespace GerenciadorMongo.Dominio.Entidades
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        //Lista de compras
        public ICollection<Pedido> Pedidos { get; set; }

        public Cliente()
        {
            Pedidos = new List<Pedido>();
        }

        public override string ToString()
        {
            return "Clientes";
        }
    }
}
