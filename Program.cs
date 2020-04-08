using System;
using System.Globalization;

namespace Vetor_com_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------- Bem Vindo ao Software Stock&Beyond™ --------\n");

            Produto[] estoque = null;

            SelecionarOpcao(estoque);

            static void SelecionarOpcao(Produto[] estoque)
            {
                Console.WriteLine("O que você deseja fazer? Escolha 1 opção. (a/b/s)\n");
                Console.WriteLine("a) Cadastrar novos produtos.");
                Console.WriteLine("b) Verificar os produtos atuais.");
                Console.WriteLine("s) Sair.\n");

                char escolha = char.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 'a':
                    case 'A':
                        CadastrarProdutos(estoque);
                        break;

                    case 'b':
                    case 'B':
                        VerificarProdutos(estoque);
                        break;

                    case 's':
                    case 'S':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Erro. Opção não identificada, tente novamente.");
                        SelecionarOpcao(estoque);
                        break;
                }

            }
            
            static void CadastrarProdutos(Produto[] estoque)
            {
                Console.WriteLine("\n-------- CADASTRO DE NOVOS PRODUTOS --------\n");

                Console.WriteLine("Quantos produtos serão estocados? ");
                int N = int.Parse(Console.ReadLine());

                if (estoque == null)
                {
                    estoque = new Produto[N];

                    for (int i = 0; i < N; i++)
                    {
                        //Opção 1 - COM CONSTRUTOR:

                        Console.WriteLine("\nItem #{0}", (i + 1));
                        Console.Write("Nome do produto: ");
                        string name = Console.ReadLine();

                        Console.Write("Preço do(a) {0}: ", name);
                        double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        estoque[i] = new Produto(name, price);

                        /* Opção 2 - SEM CONSTRUTOR, instanciando ANTES:

                            Produto p = new Produto();
                            estoque[i] = p;
                            Console.WriteLine("\nItem #{0}", (i + 1));

                            Console.Write("Nome do produto: ");
                            p.Nome = Console.ReadLine();

                            Console.Write("Preço do(a) {0}: ", p.Nome);
                            p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        */

                        /* Opção 3 - SEM CONSTRUTOR, instanciando DEPOIS: 

                            Console.Write("Nome do produto: ");
                            string name = Console.ReadLine();

                            Console.Write("Preço do(a) {0}: ", name;
                            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            estoque[i] = new Produto() { Nome = name, Preco = price };
                        */
                    }
                }
                else
                {
                    Array.Resize(ref estoque, estoque.Length + N);
                    for (int i = estoque.GetLowerBound(0); i <= estoque.GetUpperBound(0); i++)
                    {
                        if (estoque[i] == null)
                        {
                            Console.WriteLine("\nItem #{0}", (i + 1));
                            Console.Write("Nome do produto: ");
                            string name = Console.ReadLine();

                            Console.Write("Preço do(a) {0}: ", name);
                            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            estoque[i] = new Produto(name, price);
                        }
                    }
                }

                Console.WriteLine("\n-------- Estoque Atualizado --------\n");

                Console.WriteLine("Digite uma tecla pra retornar ao Menu Principal e pressione 'ENTER'.");
                string voltar = Console.ReadLine();

                if (voltar != null)
                {
                    Console.Clear();
                    SelecionarOpcao(estoque);
                }
            }

            static void VerificarProdutos(Produto[] estoque)
            {
                double soma = 0.0;
                int N = 0;

                Console.WriteLine("\n-------- RELATÓRIO DE ESTOQUE ATUAL --------\n");

                if (estoque != null)
                {                        
                    var i = 0;
                    foreach (var item in estoque)
                    {

                        Console.WriteLine("\nItem #{0}", (i + 1));
                        i++;

                        Console.WriteLine(item);

                        soma += item.Preco;
                        N++;
                    }

                    Console.WriteLine("Total de produtos em estoque: " + N);
                    Console.WriteLine("Valor total em estoque: R$" + soma.ToString("F2", CultureInfo.InvariantCulture));
                    Console.WriteLine("Preço médio dos produtos em estoque: R$" + (soma / N).ToString("F2", CultureInfo.InvariantCulture));
                }
                else 
                {
                    Console.WriteLine("ESTOQUE VAZIO.");
                }

                Console.WriteLine("\n-------- Fim do Relatório --------\n");

                Console.WriteLine("Digite uma tecla pra retornar ao Menu Principal e pressione 'ENTER'.");
                string voltar = Console.ReadLine();

                if(voltar != null)
                {
                    Console.Clear();
                    SelecionarOpcao(estoque);
                }
            }
     
        }
    }
}
