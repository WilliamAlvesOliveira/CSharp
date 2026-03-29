using Microsoft.VisualBasic;
using System;
using System.Threading;

namespace Jokenpo
{

    class Program
    {
        const string RESET = "\u001b[0m";
        const string RED = "\u001b[31m";
        const string GREEN = "\u001b[32m";
        const string YELLOW = "\u001b[33m";
        const string BLUE = "\u001b[34m";
        const string CYAN = "\u001b[36m";
        const string BOLD = "\u001b[1m";

        static void Main(string[] args)
        {
            string[] jokenpo = { "PEDRA", "PAPEL", "TESOURA" };
            bool hasWinner;
            string winnerName = "";

            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine("|                *** JOKENPO ***              |");
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine($"|Opção {CYAN}[1]PEDRA{RESET}                               |");
            Console.WriteLine($"|Opção {CYAN}[2]PAPEL{RESET}                               |");
            Console.WriteLine($"|Opção {CYAN}[3]TESOURA{RESET}                             |");
            Console.Write("|                        Digite a sua opção: "+ GREEN);
            int option = int.Parse(Console.ReadLine());
            
            Random rnd = new Random();
            int computer = rnd.Next(1, 4);
            
            Console.WriteLine(RESET + "|---------------------------------------------|");
            Console.WriteLine        ("|                                             |");
            Console.Write        ($"|{CYAN}                   Jo");
            Thread.Sleep(500);
            Console.Write("ken");
            Thread.Sleep(500);
            Console.WriteLine($"po{RESET}                   |");
            Thread.Sleep(500);
            Console.WriteLine("|                                             |");
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine("|                                             |");
            Console.WriteLine(
                $"|{BOLD}{$"PLAYER [{jokenpo[option - 1]}]",21} x {$"[{jokenpo[computer - 1]}] COMPUTADOR",-21}{RESET}|");
            Console.WriteLine("|                                             |");

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

            Console.WriteLine("|---------------------------------------------|");

        }
    }
}




