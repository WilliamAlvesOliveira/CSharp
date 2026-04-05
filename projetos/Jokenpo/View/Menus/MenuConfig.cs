using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jokenpo.View.TableRender;
using static Jokenpo.Models.Colors;

namespace Jokenpo.View.Menus
{
    public static class MenuConfig
    {
        public static MenuOption[] Options = new MenuOption[]
        {
            new MenuOption { Label = "Dificuldade", Values = new[] { "Fácil","Médio", "Difícil" }, CurrentIndex = 0 },
            new MenuOption { Label = "Número de Partidas", Values = new[] { "1", "3", "5" }, CurrentIndex = 1 },
            new MenuOption { Label = "Opção 3", Values = new[] { "Sim", "Não" }, CurrentIndex = 0 }
        };

        public static void Run()
        {
            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                RenderSettingScreen(selectedIndex);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0) selectedIndex--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedIndex < Options.Length - 1) selectedIndex++;
                        break;

                    case ConsoleKey.LeftArrow:
                        Options[selectedIndex].PreviousValue();
                        break;

                    case ConsoleKey.RightArrow:
                        Options[selectedIndex].NextValue();
                        break;

                    case ConsoleKey.Enter:
                        running = false;
                        break;
                }
            }
        }

        public static void RenderSettingScreen(int selectedIndex)
        {
            Console.Clear();
            Render.DrawLine('=');
            Render.JumpLine();
            Render.Text($"{BOLD}Configurações{RESET}");
            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();

            for (int i = 0; i < Options.Length; i++)
            {
                bool isSelected = (i == selectedIndex);

                if (isSelected)
                {
                    Render.Text($"{BOLD}{Options[i].Label}{RESET}:{BG_WHITE}{BLUE}{$" {Options[i].CurrentValue} "}{RESET}", "L");
                }
                else
                {
                    Render.Text($"{Options[i].Label}: {Options[i].CurrentValue}", "L");
                }


            }

            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();
            Render.Text("[Cima/Baixo] para navegar","l");
            Render.Text("[Direita/Esquerda] para alterar valores","l");
            Render.JumpLine();
            Render.Text("ENTER para sair.","l");
            Render.JumpLine();
            Render.DrawLine('=');
        }
    }

    public class MenuOption
    {
        public string Label { get; set; }
        public string[] Values { get; set; }
        public int CurrentIndex { get; set; }

        public string CurrentValue => Values[CurrentIndex];

        public void NextValue()
        {
            if (CurrentIndex < Values.Length - 1)
                CurrentIndex++;
        }

        public void PreviousValue()
        {
            if (CurrentIndex > 0)
                CurrentIndex--;
        }
    }
}
