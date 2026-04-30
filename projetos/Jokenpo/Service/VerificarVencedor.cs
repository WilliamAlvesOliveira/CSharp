using Jokenpo.View.TableRender;
using static Jokenpo.Models.Colors;
using Jokenpo.Service;



namespace Jokenpo.Service
{
    public static class Verificador
    {
            public static (string vencedor, int cpu)
        
            VerificarVencedor(int playerOption, double choiseTime)
            {
                Render.Text($"opção {playerOption} tempo {choiseTime}");
                Render.DrawLine('=');

                if (playerOption == -1)
                {
                    return ("Timeout", 0);
                }

                int computer = GameAI.GetMove(playerOption, choiseTime);

                if (playerOption == computer)
                {
                    return ("Empate", computer);
                }
                else if (playerOption == 1 && computer == 3 ||
                    playerOption == 2 && computer == 1 ||
                    playerOption == 3 && computer == 2)
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
