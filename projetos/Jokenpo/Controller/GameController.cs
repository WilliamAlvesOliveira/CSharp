using Jokenpo.Models;
using Jokenpo.View.Game;
using Jokenpo.View.Menus;

namespace Jokenpo.Controller
{
    public class GameController
    {
        public static void APP()
        {
            var stateManager = new StateManager();

            while (true)
            {
                switch (stateManager.CurrentState)
                {
                    case GameState.MenuPrincipal:
                        MenuPrincipal.Run(stateManager);
                        break;

                    case GameState.MenuConfig:
                        MenuConfig.Run();
                        // ao sair do MenuConfig, volta para o principal
                        stateManager.ChangeState(GameState.MenuPrincipal);
                        break;

                    case GameState.Game:
                        while (true)
                        {
                            GameScreen.GamePlay();
                            int restart = GameScreen.RestartMessage();
                            if (restart == 2) break;
                        }
                       
                        stateManager.ChangeState(GameState.MenuPrincipal);
                        break;

                    case GameState.Stats:
                        // aqui você pode criar uma tela de status
                        Console.Clear();
                        Console.WriteLine("Exibindo estatísticas...");
                        Console.ReadKey();
                        stateManager.ChangeState(GameState.MenuPrincipal);
                        break;
                }
            }
        }
    }
}
