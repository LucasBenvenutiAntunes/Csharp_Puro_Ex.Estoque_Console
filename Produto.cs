using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Vetor_com_Classes
{
    class Produto
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        //CONSTRUTOR:
        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        public override string ToString()
        {
            return 
                "Produto: " 
                + this.Nome 
                + "\nPreço: R$" 
                + this.Preco.ToString("F2", CultureInfo.InvariantCulture)
                + "\n";
        }

    }

}
