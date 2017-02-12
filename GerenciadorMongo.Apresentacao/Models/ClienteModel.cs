using System.Collections.Generic;

namespace GerenciadorMongo.Apresentacao.Models
{
    public class ClienteModel : Model
    {
        private string nome;
        private string endereco;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged("Nome");
            }
        }
        public string Endereco
        {
            get { return endereco; }
            set
            {
                endereco = value;
                OnPropertyChanged("Endereco");
            }
        }

        //Lista de compras
        public List<PedidoModel> Pedidos { get; set; }

        public ClienteModel()
        {
            Pedidos = new List<PedidoModel>();
        }
    }
}
