using System;

namespace AUTO_PROPERTIES
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto("Café", 15.00, 3);

            Console.WriteLine("Nome: " + p1.Nome);
            Console.WriteLine("Preço: " + p1.Preco);
            Console.WriteLine("Quantidade: " + p1.Quantidade);

            Console.WriteLine("-------------------------");

            // Alterando valores
            //p1.Preco = 18.00;

            // p1.Quantidade = 10; ❌ não é permitido (set privado)

            p1.AdicionarEstoque(5);

            Console.WriteLine("Após alterações:");

            Console.WriteLine("Nome: " + p1.Nome);
            Console.WriteLine("Preço: " + p1.Preco);
            Console.WriteLine("Quantidade: " + p1.Quantidade);

            Console.WriteLine(new String('-', 25));

            p1.AtualizarPreco(-10.00);
        }
    }

    public class Produto
    {
        /*
         AUTO PROPERTIES = forma mais simples de criar properties

         O C# cria automaticamente um "campo oculto" (backing field)

         Ou seja:
         você não precisa escrever:

         private int quantidade;

         O compilador cria isso para você
        */

        // Auto property simples
        public string Nome { get; set; }

        /*
         Auto property com validação indireta:
         Aqui usamos set privado para proteger alterações externas
        */
        public double Preco { get; private set; }

        public int Quantidade { get; private set; }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        /*
         Como o SET é privado, precisamos de métodos
         para alterar os valores de forma controlada
        */

        public void AtualizarPreco(double novoPreco)
        {
            if (novoPreco > 0)
            {
                Preco = novoPreco;
            }
            else
            {
                Console.WriteLine("Preço inválido!");
            }
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade > 0)
            {
                Quantidade += quantidade;
            }
            else
            {
                Console.WriteLine("Quantidade inválida!");
            }
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade > 0 && quantidade <= Quantidade)
            {
                Quantidade -= quantidade;
            }
            else
            {
                Console.WriteLine("Operação inválida!");
            }
        }
    }
}