using static System.Globalization.CultureInfo;

namespace Construtores
{
    public class Produto
    {
        public string Nome;
        public double Preco;
        public int Qtd;

        public void DadosDoProduto()
        {
            Console.WriteLine($"Produto: {Nome}\nPreço: {Preco.ToString("F2", InvariantCulture)}\nQuantidade: {Qtd}");
        }

        public override string ToString()
        {
            return $"{Nome}, $ {Preco.ToString("F2", InvariantCulture)}, {Qtd} unidades, total: {ValorTotalEstoque().ToString("F2", InvariantCulture)}";
        }

        public double ValorTotalEstoque()
        {
            return Preco * Qtd;
        }

        public void AdicionarProduto(int qtd)
        {
            if (qtd >= 0)
            {
                Qtd += qtd;
            }
            else
            {
                Console.WriteLine("Quantidade Inválida!");
                Console.Write("\n");
            }
        }

        public void RemoverProduto(int qtd)
        {
            if (qtd >= 0 && qtd <= Qtd)
            {
                Qtd -= qtd;
            }
            else
            {
                Console.WriteLine("Quantidade Inválida!");
                Console.Write("\n");
            }
        }
    }

    public class ProdutoWithConstructor
    {
        public string Nome;
        public double Preco;
        public int Qtd;

        /*
         * CONSTRUTOR DA CLASSE:
         * 
         * O construtor é um método especial que possui o MESMO NOME da classe.
         * Ele é chamado automaticamente no momento em que criamos um objeto (new).
         * 
         * Diferente dos métodos comuns:
         * - Não possui tipo de retorno (nem mesmo void)
         * - Serve para inicializar o objeto com valores obrigatórios
         */
        public ProdutoWithConstructor(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Qtd = quantidade;
        }

        //SOBRECARGA
        public ProdutoWithConstructor(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
            Qtd = 1;
        }

        public void DadosDoProduto()
        {
            Console.WriteLine($"Produto: {Nome}\nPreço: {Preco.ToString("F2", InvariantCulture)}\nQuantidade: {Qtd}");
        }

        public override string ToString()
        {
            return $"{Nome}, $ {Preco.ToString("F2", InvariantCulture)}, {Qtd} unidades, total: {ValorTotalEstoque().ToString("F2", InvariantCulture)}";
        }

        public double ValorTotalEstoque()
        {
            return Preco * Qtd;
        }

        public void AdicionarProduto(int qtd)
        {
            if (qtd >= 0)
            {
                Qtd += qtd;
            }
            else
            {
                Console.WriteLine("Quantidade Inválida!");
                Console.Write("\n");
            }
        }

        public void RemoverProduto(int qtd)
        {
            if (qtd >= 0 && qtd <= Qtd)
            {
                Qtd -= qtd;
            }
            else
            {
                Console.WriteLine("Quantidade Inválida!");
                Console.Write("\n");
            }
        }
    }
}
