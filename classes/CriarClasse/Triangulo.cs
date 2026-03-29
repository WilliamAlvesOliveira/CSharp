using System.Reflection.Metadata.Ecma335;

namespace CriarClasse
{
    class Triangulo
    {
        public double A;
        public double B;
        public double C;

        public void MostrarLados()
        {
            Console.WriteLine("Lado 1: " + A);
            Console.WriteLine("Lado 2: " + B);
            Console.WriteLine("Lado 3: " + C);
        }

        public double Area()
        {
            double p = (A + B + C) / 2.0;
            double area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));

            return area;     
        }
    }
}
