using System;
using System.Globalization;

namespace MembrosEstaticos_pt2
{
    /* 
     * Classes estáticas ou membros estáticos são úteis quando:
     * - Não há necessidade de criar instâncias (objetos) da classe.
     * - Os métodos e propriedades representam comportamentos ou valores universais.
     * - Exemplo: cálculos matemáticos, constantes físicas, utilitários de conversão.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Chamando métodos estáticos diretamente pela classe
            double circunferencia = Calculadora.Circunferencia(raio);
            Console.WriteLine(
                $"A circunferência do raio {raio} é {circunferencia.ToString("F2", CultureInfo.InvariantCulture)}"
            );

            double volume = Calculadora.Volume(raio);
            Console.WriteLine(
                $"Volume da esfera de raio {raio} é {volume.ToString("F2", CultureInfo.InvariantCulture)}"
            );

            // Acessando constante estática
            Console.WriteLine(
                "O valor de PI é " + Calculadora.PI.ToString("F2", CultureInfo.InvariantCulture)
            );
        }
    }

}