using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpo.Models
{
    public static class GameSettings
    {
        // 🎮 Dificuldade atual
        public static Difficulty Difficulty => Settings.CurrentDifficulty;

        public static int GameLevel => (int)Settings.CurrentDifficulty;

        public static int Rounds => Settings.CurrentRounds;

        // 🏷️ Nome da dificuldade (pra UI)
        public static string DifficultyLabel => Difficulty.ToString();

        // 🎯 Modo (melhor de X partidas)
        public static int Mode
        {
            get
            {
                return int.Parse(Settings.SettingsOptions.Options[1].CurrentValue);
            }
        }

        // 📊 Stats da dificuldade atual
        public static Settings.GameStats Stats
        {
            get
            {
                return Settings.StatsByDifficulty[Difficulty];
            }
        }
    }
}
