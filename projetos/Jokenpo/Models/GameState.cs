using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpo.Models
{
    public enum GameState
    {
        MenuPrincipal,
        MenuConfig,
        Game,
        Stats
    }

    public class StateManager
    {
        public GameState CurrentState { get; private set; } = GameState.MenuPrincipal;

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            Console.WriteLine($"Estado alterado para: {CurrentState}");
        }
    }
}
