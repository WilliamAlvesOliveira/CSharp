using System;

namespace Construtores;

class Program
{
    static void Main(string[] args)
    {
        /*
         * CONSTRUTOR:
         * É um método especial de uma classe que é executado automaticamente
         * no momento em que um objeto é criado (instanciado).
         * 
         * Ele é muito útil para garantir que o objeto já nasça com valores válidos.
         */

        // Exemplo 1: Criando um objeto da classe Produto (sem construtor personalizado)
        Produto produto1 = new Produto();

        /*
         * Como não definimos um construtor na classe Produto,
         * o C# utiliza um construtor padrão (default),
         * que inicializa os atributos com valores padrão:
         * - string -> null
         * - números -> 0
         */

        // Exibindo o estado atual do objeto
        Console.WriteLine(produto1);

        /*
         * Problema:
         * O objeto foi criado sem nome e sem preço.
         * Em um cenário real, isso pode gerar inconsistências,
         * pois um produto deveria sempre ter esses dados.
         */

        /*
         * Solução:
         * Criar um construtor que obrigue o envio dos dados essenciais
         * no momento da criação do objeto.
         */

        // Exemplo 2: Criando um objeto com construtor obrigatório
        ProdutoWithConstructor produto2 = new ProdutoWithConstructor("Arroz", 10.00, 1);
        Console.WriteLine(produto2);

        /*
         * Agora, a classe ProdutoWithConstructor exige que o nome e o preço
         * sejam informados no momento da instância.
         * 
         * Isso garante que o objeto já seja criado em um estado válido,
         * evitando erros futuros.
         */

        ProdutoWithConstructor produto3 = new ProdutoWithConstructor("Arroz", 10.00);
        Console.WriteLine(produto3);

    }
}