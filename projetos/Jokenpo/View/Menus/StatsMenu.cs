using Jokenpo.Models;
using Jokenpo.View.TableRender;
using static Jokenpo.Models.Colors;
using static Jokenpo.Models.Settings;

namespace Jokenpo.View.Menus
{
    public static class StatsMenu
    {
        public enum StatsPage
        {
            Overview,
            Moves,
            Advanced
        }

        public enum Difficulty
        {
            Fácil,
            Médio,
            Difícil
        }

        public static void Run()
        {
            int pageIndex = 0;
            int difficultyIndex = 0;
            bool running = true;


            while (running)
            {
                var page = (StatsPage)pageIndex;
                var difficulty = (Difficulty)difficultyIndex;
                var stats = Settings.StatsByDifficulty[Settings.CurrentDifficulty];

                RenderScreen(page, difficulty, stats);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        pageIndex--;
                        break;

                    case ConsoleKey.DownArrow:
                        pageIndex++;
                        break;

                    case ConsoleKey.LeftArrow:
                        difficultyIndex--;
                        break;

                    case ConsoleKey.RightArrow:
                        difficultyIndex++;
                        break;

                    case ConsoleKey.Enter:
                        running = false;
                        break;
                }

                pageIndex = Math.Clamp(pageIndex, 0, Enum.GetValues(typeof(StatsPage)).Length - 1);
                difficultyIndex = Math.Clamp(difficultyIndex, 0, Enum.GetValues(typeof(Difficulty)).Length - 1);
            }
        }

        public static void RenderScreen(StatsPage page, Difficulty difficulty, GameStats stats)
        {
            RenderStatHeader(page, difficulty);

            switch (page)
            {
                case StatsPage.Overview:
                    RenderOverviewScreen(difficulty, page, stats);
                    break;

                case StatsPage.Moves:
                    RenderMovesScreen(difficulty, page, stats);
                    break;

                case StatsPage.Advanced:
                    RenderAdvancedScreen(difficulty, page, stats);
                    break;
            }

            RenderStatFooter();
        }

        public static void RenderStatHeader(StatsPage page, Difficulty difficulty)
        {
            Console.Clear();
            Render.DrawLine('=');
            Render.JumpLine();
            Render.Text($"{BOLD}Player Stats{RESET}");
            Render.Text($"Dificuldade: {difficulty}");
            Render.Text($"Página {(int)page + 1}/{Enum.GetValues(typeof(StatsPage)).Length}", "R");
            Render.DrawLine();
        }

        public static void RenderStatFooter()
        {
            Render.JumpLine();
            Render.DrawLine();
            Render.Text($"{BOLD}Navegação{RESET}");
            Render.Text($"{BOLD}Cima/Baixo{RESET} Páginas", "L");
            Render.Text($"{BOLD}Direita/Esquerda{RESET} Dificuldade", "L");
            Render.Text($"{BOLD}ENTER{RESET} Sair", "L");
            Render.DrawLine('=');
        }

        public static void RenderOverviewScreen(Difficulty difficulty, StatsPage page, GameStats stats)
        {   
            Render.JumpLine();
            Render.Text($"Partidas jogadas: {stats.TotalGames}", "L");
            Render.Text($"Vitórias: {stats.Wins}", "L");
            Render.Text($"Derrotas: {stats.Losses}", "L");
            Render.Text($"Empates: {stats.Draws}", "L");

            Render.JumpLine();
            Render.Text($"Sequência atual: {stats.CurrentWinStreak} vitórias", "L");
            Render.Text($"Maior sequência de vitórias: {stats.MaxWinStreak}", "L");
            Render.Text($"Maior sequência de derrotas: {stats.MaxLoseStreak}", "L");
            Render.JumpLine();
            Render.JumpLine();
        }

        public static void RenderMovesScreen(Difficulty difficulty, StatsPage page, GameStats stats)
        {
            Render.JumpLine();
            Render.Text("Tela de jogadas (em construção)");
            for(int times = 0; times < 9; times++)
            {
                Render.JumpLine();
            }
        }

        public static void RenderAdvancedScreen(Difficulty difficulty, StatsPage page, GameStats stats)
        {
            Render.JumpLine();
            Render.Text("Tela avançada (em construção)");
            for (int times = 0; times < 9; times++)
            {
                Render.JumpLine();
            }

        }
    }
}