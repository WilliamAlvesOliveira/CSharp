namespace MembrosEstaticos_pt2
{
    class Calculadora
    {
        // Constante estática: valor fixo e imutável, acessível sem instanciar a classe
        public const double PI = 3.14159;

        // Método estático: não depende de atributos de instância
        public static double Circunferencia(double raio)
        {
            return 2.0 * PI * raio;
        }

        public static double Volume(double raio)
        {
            return 4.0 / 3.0 * PI * Math.Pow(raio, 3);
        }
    }

}
