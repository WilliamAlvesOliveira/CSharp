using System;

namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, Mundo!");
            Console.WriteLine("Primeiro log no Visual Code");
            Console.Write("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine($"O antecessor de {numero} é {numero - 1} " +
                $"\nE o sucessor é {numero + 1}");
        }
    }
}