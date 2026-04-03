using Microsoft.VisualBasic;
using System;
using System.Threading;
using static Jokenpo.Models.Colors;
using Jokenpo.View.TableRender;



namespace Jokenpo
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] jokenpo = { "PEDRA", "PAPEL", "TESOURA" };
            bool hasWinner;
            string winnerName = "";

            TableRender.DrawLine('=');
            TableRender.Text("*** JOKENPO ***");
            TableRender.DrawLine();
            TableRender.Text("Selecione a sua opção:", "L");
            TableRender.JumpLine();
            TableRender.Text($"Opção {CYAN}[1]PEDRA{RESET}", "L");
            TableRender.Text($"Opção {CYAN}[2]PAPEL{RESET}", "L");
            TableRender.Text($"Opção {CYAN}[3]TESOURA{RESET}","L");
            TableRender.Text($"Digite a sua opção: {GREEN}","r","noWrap");
            
            int option = int.Parse(Console.ReadLine());
            Console.Write(RESET);
            
            Random rnd = new Random();
            int computer = rnd.Next(1, 4);
            
            Console.Write(RESET);
            TableRender.DrawLine();
            TableRender.JumpLine();
            Console.Write        ($"|{CYAN}                   Jo");
            Thread.Sleep(500);
            Console.Write("ken");
            Thread.Sleep(500);
            Console.WriteLine($"po{RESET}                   |");
            Thread.Sleep(500);
            TableRender.JumpLine();
            TableRender.DrawLine();
            TableRender.JumpLine();
            Console.WriteLine(
                $"|{BOLD}{$"PLAYER [{jokenpo[option - 1]}]",21} x {$"[{jokenpo[computer - 1]}] COMPUTADOR",-21}{RESET}|");
            TableRender.JumpLine();

            if (option == computer) {
                hasWinner = false;
            }
            else if (option == 1 && computer == 3 ||
                option == 2 && computer == 1 ||
                option == 3 && computer == 2)
            {
                hasWinner = true;
                winnerName = "Player";
            }
            else
            {
                hasWinner = true;
                winnerName = "Computer";
            }

            if (hasWinner)
            {
                Console.WriteLine($"| {BLUE}VENCEDOR: {$"{(winnerName == "Player"? GREEN : RED)}{winnerName,-12}{RESET}"}                      |");
            }
            else
            {
                Console.WriteLine($"| {YELLOW}EMPATE{RESET}                                      |");
            }

            TableRender.DrawLine('=');

        }
    }
}
