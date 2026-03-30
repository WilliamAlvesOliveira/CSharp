using System;
// Importa funcionalidades básicas do C# (Console, tipos primitivos, etc.)

using static System.Globalization.CultureInfo;
// Permite usar "InvariantCulture" diretamente, sem precisar escrever CultureInfo.InvariantCulture

namespace GestordeEstoque
{
    // Define a classe Produto (molde/estrutura de um produto)
    public class Produto
    {
        // Campos públicos (dados do produto)
        // Representam o estado do objeto

        public string Nome;
        // Nome do produto (ex: "Arroz")

        public double Preco;
        // Preço do produto
        // ⚠️ Aqui seria mais ideal usar decimal para evitar problemas de precisão

        public int Qtd;
        // Quantidade em estoque

        // Método responsável por exibir os dados do produto no console
        public void DadosDoProduto()
        {
            // "F2" → formata com 2 casas decimais
            // InvariantCulture → garante uso de ponto (.) como separador decimal
            Console.WriteLine($"Produto: {Nome}\nPreço: {Preco.ToString("F2", InvariantCulture)}\nQuantidade: {Qtd}");
        }

        // Sobrescrita do método ToString()
        // Permite definir como o objeto será exibido quando convertido para string
        public override string ToString()
        {
            return $"{Nome}, $ {Preco.ToString("F2", InvariantCulture)}, {Qtd} unidades, total: {ValorTotalEstoque().ToString("F2", InvariantCulture)}";
        }

        // Método que calcula o valor total do estoque
        // Multiplica preço pela quantidade
        public double ValorTotalEstoque()
        {
            return Preco * Qtd;
        }

        // Método para adicionar produtos ao estoque
        public void AdicionarProduto(int qtd)
        {
            // Soma a quantidade atual com a quantidade informada
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

        // Método para remover produtos do estoque
        public void RemoverProduto(int qtd)
        {
            // Subtrai a quantidade atual
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