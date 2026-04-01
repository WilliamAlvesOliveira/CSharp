using System;
using System.Globalization;

/* */
namespace MembrosEstaticos_pt1;
/*
 * São membros que fazem sentido independentemente de objetos. Não 
precisam de objeto para serem chamados.São chamados a partir do 
próprio nome da classe.

 - Uma classe que possui somente membros estáticos, pode ser uma classe 
estática também. Esta classe não poderá ser instanciada.
*/

class Program
{   
    //definição de um valor estático deve por convenção ser feito no inicio do programa
    static double PI = 3.14;


    /* um exemplo de método estático é o proprio método Main que é um membro estático da classe Program
     * - static indica que é um membro estático
     * - void indica que não possui um retorno
     * - Main() é o nome do método
     */
    static void Main(string[] args) 
    {

        Console.WriteLine("Entre com o valor do raio: ");
        //InvariantCulture é um exemplo de método estático da classe CultureInfo
        double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double circunferencia = Circunferencia(raio);

        Console.WriteLine($"A circunfêrencia do raio {raio} é {circunferencia.ToString("F2", CultureInfo.InvariantCulture)}");

        double volume = Volume(raio);

        Console.WriteLine($"Volume da circunferência de raio {raio} é {volume.ToString("F2", CultureInfo.InvariantCulture)}");

        Console.WriteLine("O valor de PI é " + PI.ToString("F2", CultureInfo.InvariantCulture));
    }

    //a gente não pode chamar uma função não estatica em uma função estatica(Main) portanto nossa função circunferencia precisa ser estática também
    static double Circunferencia(double _raio)
    {
        return 2.0 * PI * _raio;
    }


    static double Volume(double _raio)
    {
        return 4.0 / 3.0 * PI * _raio * _raio * _raio;
        //poderiamos elevar usando o método Pow(_raio)
    }
}