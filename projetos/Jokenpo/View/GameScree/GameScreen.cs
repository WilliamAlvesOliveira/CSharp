
using Microsoft.VisualBasic.FileIO;
using System;
using static Jokenpo.Models.Colors;
using static Jokenpo.Service.Verificador;
using Render = Jokenpo.View.TableRender.Render;



namespace Jokenpo.View.Game
{
    public class GameScreen
    {
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

            var(option, tempo) = PlayerInputWithTimer(10);

            Console.Clear();
            Render.Header();
            Thread.Sleep(500);

            var (vencedor, CPU) = Service.Verificador.VerificarVencedor(option, tempo);
            ShowResults(option, vencedor, CPU);
        }

        public static void ShowResults(int option, string vencedor, int computer)
        {
            string[] jokenpo = { "PEDRA", "PAPEL", "TESOURA" };
            
            if(vencedor.ToLower() == "timeout")
            {
                Render.JumpLine();
                Render.Text($"{RED}TIMEOUT!{RESET} Você perdeu por não escolher a tempo.");
                Render.JumpLine();
                Render.DrawLine('=');
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
            Console.WriteLine(
                $"|{BOLD}{$"PLAYER [{jokenpo[option - 1]}]",21} x {$"[{jokenpo[computer - 1]}] COMPUTADOR",-21}{RESET}|");
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

        }

        public static (int option, double choseTime) PlayerInputWithTimer(int segundos = 10)
        {
            int option = -1;
            var cts = new CancellationTokenSource();
            double choseTime = 0;

            DateTime startTime = DateTime.Now; // início da contagem


            // Task para ler entrada
            Task inputTask = Task.Run(() =>
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    option = result;
                }

                DateTime endTime = DateTime.Now; // fim da contagem
                TimeSpan elapsed = endTime - startTime;

                choseTime = elapsed.TotalSeconds;

                cts.Cancel(); // cancela o timer se o jogador digitou
            });

            // Task para o timer
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
            });

            Task.WaitAny(new[] { inputTask, timerTask }); // espera quem terminar primeiro
            return (option, choseTime);
        }
        
        public static int RestartMessage()
        {
            Thread.Sleep(5000);
            Console.Clear();
            Render.DrawLine('=');
            Render.JumpLine();
            Render.Text("Deseja Jogar Novamente?");
            Render.JumpLine();
            Render.Text($"[1]{GREEN}Sim{RESET} / [2]{RED}Não{RESET}");
            Render.Text("","c","nowrap");
            Render.JumpLine();
            Render.DrawLine('=');

            int response = int.Parse(Console.ReadLine());
            int line = Console.CursorTop;        

            return response;
        }

    }
}
