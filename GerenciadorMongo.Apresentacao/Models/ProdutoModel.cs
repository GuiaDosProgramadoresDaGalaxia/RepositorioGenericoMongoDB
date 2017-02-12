namespace GerenciadorMongo.Apresentacao.Models
{
    public class ProdutoModel : Model
    {
        private string nome;
        private decimal valor;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged("Nome");
            }
        }

        public decimal Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                OnPropertyChanged("Valor");
            }
        }
    }
}
