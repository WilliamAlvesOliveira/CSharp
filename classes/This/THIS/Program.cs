using System;

namespace THIS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um objeto da classe Produto
            Produto p1 = new Produto("Arroz", 5.50, 10);

            // Chamando um método que usa THIS internamente
            p1.MostrarDados();

            // Atualizando o preço usando um método com THIS
            p1.AtualizarPreco(6.00);

            p1.MostrarDados();
        }
    }

    public class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;

        // Construtor
        public Produto(string Nome, double Preco, int Quantidade)
        {
            /*
             THIS é usado aqui para diferenciar:
             
             - atributo da classe (this.Nome)
             - parâmetro do método (Nome)

             Sem o THIS, o compilador entenderia apenas o parâmetro
            */
            this.Nome = Nome;
            this.Preco = Preco;
            this.Quantidade = Quantidade;
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Produto: {this.Nome}");
            Console.WriteLine($"Preço: {this.Preco}");
            Console.WriteLine($"Quantidade: {this.Quantidade}");
            Console.WriteLine("----------------------------");
        }

        public void AtualizarPreco(double Preco)
        {
            /*
             THIS garante que estamos alterando
             o atributo da instância atual
            */
            this.Preco = Preco;
        }
    }
}