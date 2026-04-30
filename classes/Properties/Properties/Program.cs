using System;

namespace PROPERTIES
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto("Macarrão", 4.50, 10);

            // Acessando como se fosse atributo (mas com proteção interna)
            Console.WriteLine("Nome: " + p1.Nome);
            Console.WriteLine("Preço: " + p1.Preco);
            Console.WriteLine("Quantidade: " + p1.Quantidade);

            Console.WriteLine("--------------------------");

            // Alterando valores
            p1.Preco = 5.00;
            p1.Quantidade = -20; // tentativa inválida

            Console.WriteLine("Após alterações:");

            Console.WriteLine("Preço: " + p1.Preco);
            Console.WriteLine("Quantidade: " + p1.Quantidade);
        }
    }

    public class Produto
    {
        /*
         PROPERTIES = forma moderna de encapsulamento

         Permitem:
         - Ler (get)
         - Alterar (set)
         - Validar dados
         
         Tudo com sintaxe simples
        */

        private string nome;
        private double preco;
        private int quantidade;

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        // PROPERTY com GET e SET completos
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                /*
                 Aqui poderíamos validar, mas nesse caso
                 qualquer nome é aceito
                */
                nome = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }
            set
            {
                /*
                 VALUE = valor que está sendo atribuído
                 Ex: p1.Preco = 5.00 → value = 5.00
                */
                if (value > 0)
                {
                    preco = value;
                }
                else
                {
                    Console.WriteLine("Preço inválido!");
                }
            }
        }

        public int Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                if (value >= 0)
                {
                    quantidade = value;
                }
                else
                {
                    Console.WriteLine("Quantidade inválida!");
                }
            }
        }
    }
}