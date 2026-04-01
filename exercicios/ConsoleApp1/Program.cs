/*
EXERCÍCIO 03: 
Fazer um programa para ler o nome de um aluno e as três notas que ele obteve no semestre do ano. Ao final, mostrar qual a nota final do aluno no 
ano. Dizer também se o aluno está APROVADO ou REPROVADO e, em caso negativo, quantos pontos faltam 
para o aluno obter o mínimo para ser aprovado (que é 6.00 pontos). Você deve criar uma classe Aluno para resolver 
este problema.
*/

using System;
using System.Globalization;

namespace Exercicio3;

class Program
{
    static void Main(string[] args)
    {
        Aluno aluno1;
        aluno1 = new Aluno();

        Console.Write("Digite o nome do aluno: ");
        aluno1.Nome = Console.ReadLine();

        //Primeiro Semestre
        Console.WriteLine("Digite as 3 notas do aluno " + aluno1.Nome);
        aluno1.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        aluno1.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        aluno1.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine(aluno1);
        Console.WriteLine(aluno1.Situacao());

    }

}
