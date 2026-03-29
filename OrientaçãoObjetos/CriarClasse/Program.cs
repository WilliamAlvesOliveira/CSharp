using CriarClasse;
using System;
using System.Globalization;

namespace CriandoClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaração das variáveis do tipo Triangulo (ainda sem instância)
            Triangulo x, y;

            // Instanciando os objetos (criando de fato os triângulos na memória)
            x = new Triangulo();
            y = new Triangulo();

            Console.WriteLine("Digite o valor dos 3 lados do primeiro triângulo: ");

            // Lendo e atribuindo os valores digitados pelo usuário
            // InvariantCulture garante que o separador decimal seja ponto (.)
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Exibindo os valores dos lados acessando diretamente as propriedades do objeto
            Console.WriteLine($"{x.A}, {x.B}, {x.C}");
            Console.WriteLine();

            Console.WriteLine("Primeiro Triângulo:");

            // Chamando um método da classe para exibir os lados
            // (melhor organização do que fazer tudo no Main)
            x.MostrarLados();
            Console.WriteLine();

            Console.WriteLine("Digite o valor dos 3 lados do segundo triângulo: ");

            // Repetindo o processo para o segundo objeto
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Segundo Triângulo:");
            y.MostrarLados();
            Console.WriteLine();

            Console.WriteLine("Mostrando area dos triângulos:");

            // Chamando o método que calcula a área e formatando com 2 casas decimais
            Console.WriteLine($"Triângulo x: {x.Area():F2}");

            // Outra forma de formatar usando ToString
            Console.WriteLine($"Triângulo y: {y.Area().ToString("F2")}");
            Console.WriteLine();

            Console.WriteLine("O triângulo de maior área é: ");

            // Comparando as áreas dos dois triângulos
            if (x.Area() == y.Area())
            {
                Console.WriteLine("Ambos tem a mesma área");
            }
            else if (x.Area() > y.Area())
            {
                Console.WriteLine("Triângulo x");
            }
            else
            {
                Console.WriteLine("Triângulo y");
            }
        }
    }
}