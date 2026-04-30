using Jokenpo.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Jokenpo.Models.Colors;
using static Jokenpo.Service.Verificador;
using Render = Jokenpo.View.TableRender.Render;

namespace Jokenpo.View.Game
{
    public class GameScreen
    {
        private static int timer = 3;
        private static int RestartSelection = 1;

        public static void GamePlay()
        {
            Console.Clear();
            Render.Header();
            Render.Text("Selecione a sua opção:", "L");
            Render.JumpLine();
            Render.Text($"Opção {CYAN}[1]PEDRA{RESET}", "L");
            Render.Text($"Opção {CYAN}[2]PAPEL{RESET}", "L");
            Render.Text($"Opção {CYAN}[3]TESOURA{RESET}", "L");
            Render.JumpLine();
            Render.Text("Tempo");

            if(GameSettings.GameLevel == 0)
            {
                timer = 5;
            }
            else
            {
                timer = 3;
            }

            var (playerOption, choiseTime) = PlayerInputWithTimer(timer);

            if (choiseTime > timer) playerOption = -1;

            Console.Clear();
            Render.Header();
            Thread.Sleep(500);
            
           
            var (vencedor, CPU) = VerificarVencedor(playerOption, choiseTime);
            ShowResults(playerOption, vencedor, CPU);
        }

        public static void ShowResults(int option, string vencedor, int computer)
        {
            string[] jokenpo = { "PEDRA", "PAPEL", "TESOURA" };

            if (vencedor.ToLower() == "timeout")
            {
                Render.JumpLine();
                Render.Text($"{RED}TIMEOUT!{RESET} Você perdeu por não escolher a tempo.");
                Render.JumpLine();
                Render.DrawLine('=');
                Thread.Sleep(1000);
                Console.Write(" Aguarde");
                Render.WaitingDots();
                return;
            }

            Render.JumpLine();
            Console.Write($"|{CYAN}                   Jo");
            Thread.Sleep(500);
            Console.Write("ken");
            Thread.Sleep(500);
            Console.WriteLine($"po{RESET}                   |");
            Thread.Sleep(500);
            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();

            Render.Text($"{BOLD}{$"PLAYER[{jokenpo[option - 1]}]"} x {$"[{jokenpo[computer - 1]}]COMPUTADOR"}{RESET}");

            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();
            Render.Text($"{BLUE}Resultado{RESET}");

            switch (vencedor.ToLower())
            {
                case "empate":
                    Render.Text($"{YELLOW}EMPATE{RESET}!");
                    break;

                case "player":
                    Render.Text($"VENCEDOR: {GREEN}Player{RESET}!");
                    break;

                case "cpu":
                    Render.Text($"VENCEDOR: {RED}Computador{RESET}!");
                    break;
            }

            Render.JumpLine();
            Render.DrawLine('=');
            Console.ReadLine();
            Thread.Sleep(500);
            Console.Write(" Aguarde");
            Render.WaitingDots();
        }

        public static (int option, double choseTime) PlayerInputWithTimer(int segundos = 10)
        {
            int option = -1;
            var cts = new CancellationTokenSource();
            double choseTime = 0;

            DateTime startTime = DateTime.Now;

            // 🔥 INPUT NÃO BLOQUEANTE
            Task inputTask = Task.Run(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    if (!Console.KeyAvailable)
                    {
                        Thread.Sleep(10);
                        continue;
                    }

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            option = 1;
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            option = 2;
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            option = 3;
                            break;

                        default:
                            continue;
                    }

                    DateTime endTime = DateTime.Now;
                    TimeSpan elapsed = endTime - startTime;
                    choseTime = elapsed.TotalSeconds;

                    cts.Cancel();
                }
            });

            // ⏱️ TIMER
            Task timerTask = Task.Run(() =>
            {
                int totalWidth = Render.CONTENT_WIDTH;

                for (int i = segundos; i >= 0; i--)
                {
                    if (cts.Token.IsCancellationRequested) break;

                    int barSize = (int)((double)i / segundos * totalWidth);
                    string filled = $"{BG_RED}{new string(' ', barSize)}{RESET}";
                    string empty = new string(' ', totalWidth - barSize);

                    Console.Write("\r");
                    Console.Write($"| {filled}{empty} |");

                    Thread.Sleep(1000);
                }

                if (!cts.Token.IsCancellationRequested)
                {
                    cts.Cancel();
                }
            });

            Task.WaitAny(inputTask, timerTask);
            Task.WaitAll(inputTask, timerTask);

            if (option == -1)
            {
                return (-1, segundos + 1); // timeout
            }

            return (option, choseTime);
        }

        public static int RestartMessage()
        {
            // 🔥 LIMPA BUFFER (resolve tecla dupla)
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            int selectedIndex = RestartSelection;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Render.DrawLine('=');
                Render.JumpLine();
                Render.Text("Deseja Jogar Novamente?");
                Render.JumpLine();

                string simOption = selectedIndex == 0
                    ? $"{BG_GREEN}{WHITE} Sim {RESET}"
                    : $"{GREEN} Sim {RESET}";

                string naoOption = selectedIndex == 1
                    ? $"{BG_RED}{WHITE} Não {RESET}"
                    : $"{RED} Não {RESET}";

                Render.Text($"{simOption} / {naoOption}", "C");

                Render.JumpLine();
                Render.DrawLine('=');

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        selectedIndex = 0;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        selectedIndex = 1;
                        break;

                    case ConsoleKey.Enter:
                        running = false;
                        break;
                }
            }

            RestartSelection = selectedIndex;

            return selectedIndex == 0 ? 1 : 2;
        }
    }
}