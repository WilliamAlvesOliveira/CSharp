using System;
using System.Globalization;

/*
 * 🔹 MEMBROS ESTÁTICOS
 * 
 * São membros que pertencem à CLASSE e não a um objeto específico.
 * Ou seja:
 * - Não precisamos instanciar (new) para usá-los
 * - São acessados diretamente pelo nome da classe
 * 
 * Exemplo: Math.Sqrt(), Console.WriteLine()
 * 
 * 👉 Quando usar?
 * Quando algo NÃO depende de dados de um objeto específico.
 */

namespace MembrosEstaticos_pt1;

class Program
{
    /*
     * 🔹 CONSTANTE
     * 
     * - "const" define um valor que NÃO pode ser alterado
     * - É automaticamente estático (não precisa escrever "static")
     * - Usamos aqui porque PI é um valor fixo da matemática
     * 
     * 👉 Boa prática: constantes em MAIÚSCULO
     */
    const double PI = 3.14;

    /*
     * 🔹 MÉTODO MAIN
     * 
     * - É o ponto de entrada do programa
     * - Sempre é static, pois o programa inicia sem criar objetos
     * 
     * 👉 Regra importante:
     * Métodos estáticos só podem acessar diretamente outros membros estáticos
     */
    static void Main(string[] args)
    {
        Console.WriteLine("Entre com o valor do raio: ");

        /*
         * 🔹 CultureInfo.InvariantCulture
         * 
         * Garante que o número será interpretado com ponto (.)
         * independente da configuração regional do sistema.
         * 
         * Ex: 3.14 em vez de 3,14
         */
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

    /*
     * 🔹 MÉTODO ESTÁTICO
     * 
     * Calcula a circunferência do círculo
     * 
     * 👉 É static porque:
     * - Não depende de nenhum objeto
     * - Precisa ser acessado dentro do Main (que é static)
     */
    static double Circunferencia(double raio)
    {
        return 2.0 * PI * raio;
    }

    /*
     * 🔹 MÉTODO ESTÁTICO
     * 
     * Calcula o volume de uma esfera
     * Fórmula: (4/3) * PI * r³
     * 
     * 👉 Observação:
     * Poderíamos usar Math.Pow(raio, 3), mas aqui foi expandido
     * para deixar o cálculo mais explícito para estudo.
     */
    static double Volume(double raio)
    {
        return 4.0 / 3.0 * PI * raio * raio * raio;
    }
}