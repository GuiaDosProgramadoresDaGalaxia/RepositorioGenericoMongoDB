using System;

namespace GerenciadorMongo.Apresentacao.Models
{
    public class PedidoProdutoModel : Model
    {
        private int quantidade;
        private decimal total;

        public int Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                CalcularTotal();
                OnPropertyChanged("Quantidade");
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

        public ProdutoModel Produto { get; set; }

        private void CalcularTotal()
        {
            if(Produto != null)
                Total = Math.Round((Quantidade * Produto.Valor), 2);
        }
    }
}
