using System;
using System.Globalization;

namespace MembrosEstaticos_pt1;

class Program
{
    const double PI = 3.14;

    static void Main(string[] args)
    {
        Console.WriteLine("Entre com o valor do raio: ");
        double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double circunferencia = Circunferencia(raio);

        Console.WriteLine(
            $"A circunferência do raio {raio} é {circunferencia.ToString("F2", CultureInfo.InvariantCulture)}"
        );

        double volume = Volume(raio);

        Console.WriteLine(
            $"Volume da esfera de raio {raio} é {volume.ToString("F2", CultureInfo.InvariantCulture)}"
        );

        Console.WriteLine(
            "O valor de PI é " + PI.ToString("F2", CultureInfo.InvariantCulture)
        );
    }


    static double Circunferencia(double raio)
    {
        return 2.0 * PI * raio;
    }

    static double Volume(double raio)
    {
        return 4.0 / 3.0 * PI * raio * raio * raio;
    }
}