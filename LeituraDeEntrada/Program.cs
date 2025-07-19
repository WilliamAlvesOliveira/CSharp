using System;

namespace LeituraDeEntradas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("digite uma frase: ");
            string saudação = Console.ReadLine();
            Console.Write("digite 3 cores (uma por vez): ");
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            string z = Console.ReadLine();

            Console.WriteLine(saudação);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine($"{x}, {y}, {z}.");

            //metodo Split() + Trim()
            Console.Write("digite 3 cores: ");
            string colors = Console.ReadLine();
            string[] vet = colors.Trim().Split();
            Console.WriteLine($"{vet[0]} {vet[1]} {vet[2]}");

            string[] vet2 = Console.ReadLine().Trim().Split();//sem variavel intermediaria
            Console.WriteLine($"{vet2[0]} {vet2[1]} {vet2[2]}");

            //convertendo tipos
            //por padrão toda entrada de dados do usuário é uma string

            int n1 = int.Parse(Console.ReadLine());//converte para int
            char s = char.Parse(Console.Read * ()); //converte para char
            double nota = double.Parse(Console.ReadLine());

        }
    }
}