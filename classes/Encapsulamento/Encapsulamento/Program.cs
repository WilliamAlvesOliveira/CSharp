using System;

namespace ENCAPSULAMENTO
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um produto
            Produto p1 = new Produto("Feijão", 7.50, 5);

            // Acessando dados através de métodos (não diretamente!)
            Console.WriteLine("Nome: " + p1.GetNome());
            Console.WriteLine("Preço: " + p1.GetPreco());
            Console.WriteLine("Quantidade: " + p1.GetQuantidade());

            Console.WriteLine("--------------------------");

            // Tentando alterar valores
            p1.SetPreco(8.00);
            p1.SetQuantidade(-10); // tentativa inválida

            Console.WriteLine("Após alterações:");

            Console.WriteLine("Preço: " + p1.GetPreco());
            Console.WriteLine("Quantidade: " + p1.GetQuantidade());
        }
    }

    public class Produto
    {
        /*
         ENCAPSULAMENTO = proteger os dados da classe

         Ao invés de deixar atributos públicos:
         public string Nome;

         Usamos PRIVATE para impedir acesso direto
        */
        private string _nome;
        private double _preco;
        private int _quantidade;

        public Produto(string nome, double preco, int quantidade)
        {
            _nome = nome;
            _preco = preco;
            _quantidade = quantidade;
        }

        // GET = método para acessar o valor
        public string GetNome()
        {
            return _nome;
        }

        public double GetPreco()
        {
            return _preco;
        }

        public int GetQuantidade()
        {
            return _quantidade;
        }

        // SET = método para modificar o valor com validação
        public void SetPreco(double preco)
        {
            /*
             Regra de negócio:
             preço não pode ser negativo
            */
            if (preco > 0)
            {
                _preco = preco;
            }
            else
            {
                Console.WriteLine("Preço inválido!");
            }
        }

        public void SetQuantidade(int quantidade)
        {
            /*
             Regra de negócio:
             quantidade não pode ser negativa
            */
            if (quantidade >= 0)
            {
                _quantidade = quantidade;
            }
            else
            {
                Console.WriteLine("Quantidade inválida!");
            }
        }
    }
}