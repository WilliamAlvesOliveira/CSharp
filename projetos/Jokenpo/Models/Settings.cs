using System.Collections.Generic;
using System.Linq;

namespace Jokenpo.Models
{
    // ===============
    // 🎯 ENUM GLOBAL 
    // ===============
    public enum Difficulty
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    public static class Settings
    {
        public static readonly string[] JOKENPO = { "PEDRA", "PAPEL", "TESOURA" };

        // =========================
        // 🎮 CONTROLE DE DIFICULDADE ATUAL
        // =========================
        public static Difficulty CurrentDifficulty = Difficulty.Easy;

        public static int CurrentRounds = 1;

        // =========================
        // 📊 STATS POR DIFICULDADE
        // =========================
        public static Dictionary<Difficulty, GameStats> StatsByDifficulty = new()
        {
            { Difficulty.Easy, new GameStats() },
            { Difficulty.Medium, new GameStats() },
            { Difficulty.Hard, new GameStats() }
        };

        // =========================
        // 🎮 MENU PRINCIPAL
        // =========================
        public static class MainMenuOptions
        {
            public static string[] Options =
            {
                "Configurações",
                "Status",
                "START GAME"
            };

            public static string CurrentOption { get; private set; } = "START GAME";

            public static void SetCurrentOption(string newOption)
            {
                if (Options.Contains(newOption))
                {
                    CurrentOption = newOption;
                }
            }
        }

        // =========================
        // ⚙️ CONFIGURAÇÕES
        // =========================
        public static class SettingsOptions
        {
            public class SettingOption
            {
                public string Label { get; set; }
                public string[] Values { get; set; }
                public int CurrentIndex { get; set; }

                public Action OnChange { get; set; }

                public string CurrentValue => Values[CurrentIndex];


                public void NextValue()
                {
                    if (CurrentIndex < Values.Length - 1)
                        CurrentIndex++;

                    OnChange?.Invoke();
                }

                public void PreviousValue()
                {
                    if (CurrentIndex > 0)
                        CurrentIndex--;

                    OnChange?.Invoke();
                }
            }

            public static SettingOption[] Options = new SettingOption[]
            {
                new SettingOption
                {
                    Label = "Dificuldade",
                    Values = new[] { "Fácil", "Médio", "Difícil" },
                    CurrentIndex = 0,
                    OnChange = UpdateDifficulty
                },

                new SettingOption
                {
                    Label = "Número de Partidas",
                    Values = new[] { "1", "3", "5" },
                    CurrentIndex = 0,
                    OnChange = UpdateRounds
                }
            };

            // ✅ Sincroniza configuração com o sistema
            public static void UpdateDifficulty()
            {
                int index = Options[0].CurrentIndex;
                CurrentDifficulty = (Difficulty)index;

            }

            public static void UpdateRounds()
            {
                int index = Options[1].CurrentIndex;
                CurrentRounds = int.Parse(Options[1].Values[index]);
            }
        }

        // =========================
        // 📊 CLASSE DE ESTATÍSTICAS
        // =========================
        public class GameStats
        {
            public int TotalGames;
            public int Wins;
            public int Losses;
            public int Draws;

            public int CurrentWinStreak;
            public int MaxWinStreak;
            public int CurrentLoseStreak;
            public int MaxLoseStreak;

            public Dictionary<string, int> MoveCount = new()
            {
                { "PEDRA", 0 },
                { "PAPEL", 0 },
                { "TESOURA", 0 }
            };

            public List<string> LastMoves = new();
        }
    }
}