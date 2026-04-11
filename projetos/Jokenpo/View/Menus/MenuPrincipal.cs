using System;
using Jokenpo.Models;
using Jokenpo.View.TableRender;
using static Jokenpo.Models.Colors;
using static Jokenpo.Models.Settings.MenuOptions;

namespace Jokenpo.View.Menus
{
    public class MenuPrincipal
    {
        public static void Run(StateManager manager)
        {
            int selectedIndex = Array.IndexOf(Options, CurrentOption);

            bool running = true;

            while (running)
            {
                Console.Clear();
                RenderMenu(selectedIndex);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = MoveSelection(selectedIndex, -1);
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = MoveSelection(selectedIndex, +1);
                        break;

                    case ConsoleKey.Enter:
                        SetCurrentOption(Options[selectedIndex]);
                        switch (CurrentOption)
                        {
                            case "Configurações":
                                manager.ChangeState(GameState.MenuConfig);
                                MenuConfig.Run();
                                manager.ChangeState(GameState.MenuPrincipal);
                                break;

                            case "Status":
                                manager.ChangeState(GameState.Stats);
                                break;

                            case "START GAME":
                                Console.Write(" Starting game");
                                Render.WaitingDots();
                               
                                manager.ChangeState(GameState.Game);
                                break;
                        }
                        running = false;
                        break;
                }
            }
        }


        private static void RenderMenu(int selectedIndex)
        {
            Render.DrawLine('=');
            Render.JumpLine();
            Render.Text($"{BOLD}Menu Principal{RESET}");
            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();
            Render.Text("Opções");
            Render.Text(Render.Option(Options[0], CurrentOption), "L");
            Render.Text(Render.Option(Options[1], CurrentOption), "L");
            Render.JumpLine();
            Render.DrawLine();
            Render.JumpLine();
            Render.Text(Render.Option(Settings.MenuOptions.Options[2], Settings.MenuOptions.CurrentOption));
            Render.JumpLine();
            Render.DrawLine('=');

        }
        private static int MoveSelection(int currentIndex, int direction)
        {
            int newIndex = currentIndex + direction;

            if (newIndex < 0) newIndex = 0;
            if (newIndex >= Options.Length) newIndex = Options.Length - 1;

            SetCurrentOption(Options[newIndex]);
            return newIndex;
        }
    } 
}