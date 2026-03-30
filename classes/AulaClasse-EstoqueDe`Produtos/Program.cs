using GestordeEstoque;
// Importa o namespace onde está a classe Produto.
// Sem isso, o C# não saberia o que é "Produto".

using static System.Globalization.CultureInfo;
// Importa os membros estáticos da classe CultureInfo.
// Isso permite usar "InvariantCulture" diretamente,
// sem precisar escrever CultureInfo.InvariantCulture toda hora.

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declara uma variável do tipo Produto
            Produto produto1;

            // Instancia (cria) um novo objeto Produto na memória
            produto1 = new Produto();

            // Solicita o nome do produto ao usuário
            Console.Write("Entre com o nome do Produto: ");

            // Lê o que o usuário digitou e armazena na propriedade Nome
            produto1.Nome = Console.ReadLine();

            // Solicita o preço do produto
            Console.Write($"Qual é o valor do produto {produto1.Nome}: ");

            // Lê o valor digitado (string) e converte para double
            // Usando InvariantCulture para garantir que o separador decimal seja "."
            // Isso evita erros dependendo da cultura do sistema
            produto1.Preco = double.Parse(Console.ReadLine(), InvariantCulture);

            // Solicita a quantidade em estoque
            Console.Write($"Digite a quantidade de {produto1.Nome} no estoque: ");

            // Converte a entrada para inteiro
            produto1.Qtd = int.Parse(Console.ReadLine());

            Console.WriteLine();

            // Chama um método da classe Produto para exibir os dados
            produto1.DadosDoProduto();

            // Calcula o valor total em estoque (preço * quantidade)
            // "F2" formata com 2 casas decimais
            // InvariantCulture garante o padrão com ponto (.)
            Console.WriteLine($"Valor Total em estoque: {produto1.ValorTotalEstoque().ToString("F2", InvariantCulture)}");

            Console.WriteLine();

            // Aqui você está usando o método ToString() sobrescrito da classe Produto
            // Isso permite imprimir o objeto diretamente de forma personalizada
            Console.WriteLine("Produto utilizando método ToString()");
            Console.WriteLine("Dados do Produto: " + produto1);

            Console.WriteLine();

            // Solicita quantidade para adicionar ao estoque
            Console.Write("Digite quantidade de produtos que serão adicionados: ");

            // Lê e converte para inteiro
            int adicionar = int.Parse(Console.ReadLine());

            // Chama método que adiciona ao estoque
            produto1.AdicionarProduto(adicionar);

            // Mostra a quantidade atualizada
            // E recalcula o valor total em estoque
            Console.WriteLine($"Quantidade atualizada! {produto1.Qtd}\nQuantidade em estoque: {produto1.ValorTotalEstoque().ToString("F2", InvariantCulture)}");

            Console.WriteLine();

            // Solicita quantidade para remover do estoque
            Console.Write("Digite quantidade de produtos que serão removidos: ");

            // Lê, converte e já passa direto como argumento do método
            produto1.RemoverProduto(int.Parse(Console.ReadLine()));

            // Mostra novamente os dados atualizados
            Console.WriteLine($"Quantidade atualizada! {produto1.Qtd}\nQuantidade em estoque: {produto1.ValorTotalEstoque().ToString("F2", InvariantCulture)}");

            Console.WriteLine();

            // Exibe os dados finais do produto
            produto1.DadosDoProduto();
        }
    }
}