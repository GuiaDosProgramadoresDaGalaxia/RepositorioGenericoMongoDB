using System;

namespace GerenciadorMongo.Dominio.Uteis
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ColecaoAttribute : Attribute
    {
        private string colecao;

        public string Nome
        {
            get { return colecao; }
            set { colecao = value; }
        }

        public ColecaoAttribute(string nome)
        {
            Nome = nome;
        }
    }
}
