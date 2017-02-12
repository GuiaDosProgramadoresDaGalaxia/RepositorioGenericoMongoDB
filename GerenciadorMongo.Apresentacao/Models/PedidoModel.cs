using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GerenciadorMongo.Apresentacao.Models
{
    public class PedidoModel : Model
    {

        private int numero;
        private decimal total;

        public int Numero
        {
            get { return numero; }
            set
            {
                numero = value;
                OnPropertyChanged("Numero");
            }
        }
        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }

        public ObservableCollection<PedidoProdutoModel> Produtos { get; set; }
        public ClienteModel Cliente { get; set; }

        public PedidoModel()
        {
            Produtos = new ObservableCollection<PedidoProdutoModel>();
        }

        public void CalcularTotal()
        {
            var soma = Produtos.Sum(c => c.Total);
            Total = Math.Round(soma, 2);
        }
    }
}
