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
                        stateManager.ChangeState(GameState.MenuPrincipal);
                        break;
                }
            }
        }
    }
}
