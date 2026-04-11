using Jokenpo.View.Menus;
using static Jokenpo.Models.Settings;

namespace Jokenpo.Models;

public static class Settings
{
    public static readonly string[] JOKENPO = { "PEDRA", "PAPEL", "TESOURA" };

    public static class MenuOptions
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

    public static class SettingsOptions
    {
        public class SettingOption
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

        public static SettingOption[] Options = new SettingOption[]
        {
            new SettingOption { Label = "Dificuldade", Values = new[] { "Fácil","Médio", "Difícil" }, CurrentIndex = 0 },
            new SettingOption { Label = "Número de Partidas", Values = new[] { "1", "3", "5" }, CurrentIndex = 1 },
            new SettingOption { Label = "Opção 3", Values = new[] { "Sim", "Não" }, CurrentIndex = 0 }
        };
    }
}
