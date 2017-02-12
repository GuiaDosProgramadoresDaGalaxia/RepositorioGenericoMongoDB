using BibliotecaSubeta.Mongo.Entidades;
using System.Collections.Generic;

namespace GerenciadorMongo.Dominio.Entidades
{
    [Colecao("Clientes")]
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
    }
}
