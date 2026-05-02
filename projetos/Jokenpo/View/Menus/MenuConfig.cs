using Jokenpo.Models;
using Jokenpo.View.TableRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jokenpo.Models.StateManager ;
using static Jokenpo.Models.Colors;
using static Jokenpo.Models.Settings.SettingsOptions;

namespace Jokenpo.View.Menus
{
    public static class MenuConfig
    {
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
}
