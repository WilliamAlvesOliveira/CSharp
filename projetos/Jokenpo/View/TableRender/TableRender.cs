using static Jokenpo.Models.Colors;
using Jokenpo.Models;

namespace Jokenpo.View.TableRender
{
    public class Render
    {
        public const int WIDTH = 45;
        public const int CONTENT_WIDTH = WIDTH - 2;
        public static void DrawLine(char caractere = '-')
        {
            Console.WriteLine($"|{new string(caractere, WIDTH)}|");
        }

        public static void JumpLine()
        {
            Console.WriteLine($"|{new string(' ', WIDTH)}|");
        }

        public static void Text(string text, string align = "c", string wrap = "wrap")
        {
            if (text.Trim() == "") return;

            string visibleText = System.Text.RegularExpressions.Regex.Replace(text, @"\x1B\[[0-9;]*m", "");

            text = text.Trim();
            if (visibleText.Length > CONTENT_WIDTH)
            {
                // Se não há espaços (palavra gigante)
                if (!text.Contains(" "))
                {
                    string parte = text.Substring(0, CONTENT_WIDTH - 1) + "-";
                    string resto = text.Substring(CONTENT_WIDTH - 1);
                    Text(parte, align);
                    Text(resto, align);
                    return;
                }
                else
                {
                    // Divide por palavras
                    string[] palavras = text.Split(' ');
                    string _linha = "";
                    foreach (string palavra in palavras)
                    {
                        if ((_linha + palavra).Length > CONTENT_WIDTH)
                        {
                            Text(_linha.Trim(), align);
                            _linha = palavra + " ";
                        }
                        else
                        {
                            _linha += palavra + " ";
                        }
                    }
                    if (_linha.Trim() != "")
                        Text(_linha.Trim(), align);
                    return;
                }
            }


            int spaces = CONTENT_WIDTH - visibleText.Length;
            string linha;

            switch (align.ToLower())
            {
                case "r":
                    linha = $"| {new string(' ', spaces)}{text} |";
                    break;

                case "l":
                    linha = $"| {text}{new string(' ', spaces)} |";
                    break;

                default:
                    int left = spaces / 2;
                    int right = spaces - left;
                    linha = $"| {new string(' ', left)}{text}{new string(' ', right)} |";
                    break;
            }

            if(wrap.ToLower() == "nowrap")
            {
                Console.Write(linha.Substring(0, linha.Length - 2));
            }
            else
            {
                Console.WriteLine(linha);
            }
               
        }

        public static void Header()
        {
            DrawLine('=');
            JumpLine();
            Text($"{BOLD}*** JOKENPO ***{RESET}");
            Text($"Dificuldade: {Jokenpo.Models.Settings.SettingsOptions.Options[0].CurrentValue}");
            DrawLine();
        }

        public static void TimerBar(int segundos = 10)
        {
            int totalWidth = CONTENT_WIDTH;

            for (int i = segundos; i >= 0; i--)
            {
                int barSize = (int)((double)i / segundos * totalWidth);

                // Parte preenchida com fundo vermelho
                string filled = $"{BG_RED}{new string(' ', barSize)}{RESET}";
                // Parte vazia normal
                string empty = new string(' ', totalWidth - barSize);

                Console.Write("\r");
                Console.Write($"| {filled}{empty} |");

                Thread.Sleep(1000);
            }

            Console.WriteLine();
        }

        public static string Option(string option, string selectedOption)
        {
            if (option == selectedOption)
            {
                return $"{BOLD}{BLUE}{BG_WHITE}{option}{RESET}";
            }
            else
            {
                return $"{option}";
            }
        }
        public static void WaitingDots()
        {
            Thread.Sleep(500);
            for (int times = 0; times < 3; times++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
        }
    }

}
