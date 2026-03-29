namespace ExercicioClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaração e instanciação de dois objetos do tipo Pessoa
            // NOTA: permitido mas não recomendado
            Pessoa pessoa1 = new Pessoa(), pessoa2 = new Pessoa();

            // Atribuindo valores ao primeiro objeto
            pessoa1.Nome = "Maria";
            pessoa1.Idade = 27;

            // Exibindo os dados da primeira pessoa
            Console.WriteLine("Pessoa 1:");
            Console.WriteLine($"    Nome {pessoa1.Nome} \n    Idade {pessoa1.Idade}");
            Console.WriteLine();

            // Atribuindo valores ao segundo objeto
            pessoa2.Nome = "João";
            pessoa2.Idade = 27;

            // Exibindo os dados da segunda pessoa
            Console.WriteLine("Pessoa 2:");
            Console.WriteLine($"    Nome {pessoa2.Nome} \n    Idade {pessoa2.Idade}");
            Console.WriteLine();

            // Variável que irá armazenar a pessoa mais velha
            // Pode ser null caso ambas tenham a mesma idade
            Pessoa maisVelha;

            // Comparando as idades das duas pessoas
            if (pessoa1.Idade > pessoa2.Idade)
            {
                maisVelha = pessoa1;
            }
            else if (pessoa1.Idade < pessoa2.Idade)
            {
                maisVelha = pessoa2;
            }
            else
            {
                // Caso de empate: nenhuma é mais velha
                maisVelha = null;
            }

            // Verificando se existe uma pessoa mais velha
            if (maisVelha != null)
            {
                Console.Write($"A Pessoa mais velha é {maisVelha.Nome} que tem {maisVelha.Idade} anos.");
            }
            else
            {
                Console.WriteLine("Todas as pessoas tem a mesma idade.");
            }
        }
    }
}