using System;
using Funcionarios;


namespace MediaSalarial;

class Program
{
    static void Main(string[] args)
    {
        //Exercício 1
        Funcionario funcionario1, funcionario2, funcionario3;

        funcionario1 = new Funcionario();
        funcionario2 = new Funcionario();

        funcionario1.Nome = "Carlos Silva";
        funcionario1.Salario = 6300.00;
        

        funcionario2.Nome = "Ana Marques";
        funcionario2.Salario = 6700.00;

        Console.Write($"A média dos salários dos funcionários {funcionario1.Nome} e {funcionario2.Nome} é ");
        Console.WriteLine((funcionario1.Salario + funcionario2.Salario) / 2);
        Console.WriteLine(new String('-',50));
        Console.WriteLine();

        //exercício 2
        funcionario3 = new Funcionario();
        funcionario3.Nome = "João Silva";
        funcionario3.Salario = 6000.00;
        funcionario3.Imposto = 1000.00;

        Console.WriteLine("Salário Líquido: " + funcionario3.SalarioLiquido());
        funcionario3.AumentarSalario(10);
        Console.WriteLine("Salário Líquido Atualizado: " + funcionario3.SalarioLiquido());

    }
}
