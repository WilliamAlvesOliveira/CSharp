using Jokenpo.View.TableRender;
using static Jokenpo.Models.Colors;



namespace Jokenpo.Service
{
    public static class Verificador
    {
        public static (string vencedor, int cpu)
            VerificarVencedor(int option, double time)
        {

            Random rnd = new Random();
            int computer = rnd.Next(1, 4);

            Render.Text($"opção {option} tempo {time}");
            Render.DrawLine('=');

            if (option == -1)
            {
                return ("Timeout", computer);
            }
            else if (option == computer)
            {
                return ("Empate", computer);
            }
            else if (option == 1 && computer == 3 ||
                option == 2 && computer == 1 ||
                option == 3 && computer == 2)
            {
                return ("Player", computer);
            }
            else
            {
                return ("CPU", computer);
            }
        }
    }
}
