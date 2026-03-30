using System;
using Funcionarios;


namespace MediaSalarial;

class Program
{
    static void Main(string[] args)
    {
        Funcionario funcionario1, funcionario2;

        funcionario1 = new Funcionario();
        funcionario2 = new Funcionario();

        funcionario1.Nome = "Carlos Silva";
        funcionario1.Salario = 6300.00;

        funcionario2.Nome = "Ana Marques";
        funcionario2.Salario = 6700.00;

        Console.Write($"A média dos salários dos funcionários {funcionario1.Nome} e {funcionario2.Nome} é ");
        Console.WriteLine((funcionario1.Salario + funcionario2.Salario) / 2);

    }
}
