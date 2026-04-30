using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
    ✔ Tempo de escolha
    ✔ Jogada mais usada
    ✔ Últimas jogadas
    ✔ Mudança após vitória/derrota
    ✔ Padrões (sequência)
    ✔ Frequência de repetição
    ✔ Aleatoriedade controlada
    ✔ Estilo da dificuldade
    ✔ Adaptação durante o jogo
 */
using Jokenpo.Models;
using static Jokenpo.Models.Settings;

namespace Jokenpo.Service
{
    public class GameAI
    {
        private static Random random = new();

        private static void AdjustByStats(Probabilities probs, GameStats stats)
        {
            // =========================
            // 🧠 Jogada mais usada
            // =========================
            var mostUsed = stats.MoveCount
                .OrderByDescending(x => x.Value)
                .First();

            var second = stats.MoveCount
                .OrderByDescending(x => x.Value)
                .Skip(1)
                .First();

            int diff = mostUsed.Value - second.Value;

            // Se a diferença for relevante → player previsível
            if (diff >= 3)
            {
                probs.Win += 15;
                probs.Random -= 10;
                probs.Lose -= 5;
            }
            else
            {
                // Jogador equilibrado
                probs.Random += 10;
                probs.Win -= 5;
                probs.Lose -= 5;
            }

            // =========================
            // 🔁 Últimas jogadas
            // =========================
            if (stats.LastMoves.Count >= 3)
            {
                var last3 = stats.LastMoves.TakeLast(3).ToList();

                bool repeating = last3.All(m => m == last3[0]);

                if (repeating)
                {
                    probs.Win += 20;
                    probs.Random -= 10;
                    probs.Lose -= 10;
                }
            }
        }

        // =========================
        // ⏱️ AJUSTE POR TEMPO
        // =========================
        private static void AdjustByTime(Probabilities probs, double choiseTime)
        {
            if (choiseTime <= 2)
            {
                Console.WriteLine("cedo");

                probs.Win += 30;
                probs.Lose -= 15;
                probs.Random -= 15;
            }
            else if (choiseTime <= 4.8)
            {
                Console.WriteLine("tempo normal");

                probs.Random += 10;
                probs.Win -= 5;
                probs.Lose -= 5;
            }
            else
            {
                Console.WriteLine("tempo crítico");

                probs.Lose += 40;
                probs.Win -= 20;
                probs.Random -= 20;
            }
        }

        // =========================
        // ⚖️ NORMALIZAÇÃO
        // =========================
        private static void Normalize(Probabilities probs)
        {
            double total = probs.Win + probs.Lose + probs.Random;

            probs.Win = (probs.Win / total) * 100;
            probs.Lose = (probs.Lose / total) * 100;
            probs.Random = (probs.Random / total) * 100;
        }

        // =========================
        // 🎲 SORTEIO
        // =========================
        private static int RollDecision(Probabilities probs)
        {
            double roll = random.NextDouble() * 100;

            if (roll < probs.Win)
                return 0; // WIN
            else if (roll < probs.Win + probs.Lose)
                return 1; // LOSE
            else
                return 2; // RANDOM
        }

        // =========================
        // 🎯 EXECUÇÃO FINAL
        // =========================
        private static int ExecuteDecision(int decision, int playerOption)
        {
            return decision switch
            {
                0 => GetCounterMove(playerOption),
                1 => GetLosingMove(playerOption),
                _ => GetRandomMove()
            };
        }
        public static int GetMove(int playerOption, double choiseTime)
        {
            int computerChoise = 0;

            switch (GameSettings.GameLevel)
            {
                case 0:
                    computerChoise = GetEasyMove(playerOption, choiseTime);
                    break;

                case 1:
                    Console.WriteLine("Jogando medio");
                    computerChoise = 1;
                    break;

                case 2:
                    Console.WriteLine("Jogando dificil");
                    computerChoise = 1;
                    break;
            }


            return computerChoise;
        }

        private static int GetRandomMove()
        {
            return random.Next(1, 4);
        }
        private static string GetMostUsedMove(GameStats stats)
        {
            return stats.MoveCount
                .OrderByDescending(x => x.Value)
                .First().Key;
        }

        private static int GetCounterMove(int player)
        {
            return player switch
            {
                1 => 2,
                2 => 3,
                3 => 1,
            };
        }

        private static int GetLosingMove(int player)
        {
            return player switch
            {
                1 => 3,
                2 => 1,
                3 => 2,
            };
        }

        private static int GetEasyMove(int playerOption, double choiseTime)
        {
            var probs = new Probabilities
            {
                Win = 30,
                Lose = 40,
                Random = 30
            };

            Console.WriteLine($"BASE -> W:{probs.Win} L:{probs.Lose} R:{probs.Random}");

            var stats = new GameStats
            {
                MoveCount = new Dictionary<string, int>
        {
            { "PEDRA", 10 },
            { "PAPEL", 5 },
            { "TESOURA", 3 }
        },
                LastMoves = new List<string> { "PEDRA", "PEDRA", "PEDRA" }
            };

            // 🧠 Stats
            AdjustByStats(probs, stats);
            Console.WriteLine($"STATS -> W:{probs.Win} L:{probs.Lose} R:{probs.Random}");

            // ⏱️ Tempo
            AdjustByTime(probs, choiseTime);
            Console.WriteLine($"TIME -> W:{probs.Win} L:{probs.Lose} R:{probs.Random}");

            // ⚖️ Normaliza
            Normalize(probs);
            Console.WriteLine($"FINAL -> W:{probs.Win:F2} L:{probs.Lose:F2} R:{probs.Random:F2}");

            // 🎲 Decide
            int decision = RollDecision(probs);

            // 🎯 Executa
            return ExecuteDecision(decision, playerOption);
        }

        // =========================
        // 🟡 MÉDIO (MISTO)
        // =========================
        private static int GetMediumMove(int playerOption, double choiseTime)
        {
            var probs = new Probabilities
            {
                Win = 33,
                Lose = 34,
                Random = 33
            };

            int computerChoise = 0;

            if (choiseTime <= 2)
            {
                Console.WriteLine("cedo");
                computerChoise = GetCounterMove(playerOption);
            }
            else if (choiseTime <= 2.8)
            {
                Console.WriteLine("tempo normal ");
                computerChoise = GetRandomMove();
            }
            else
            {
                Console.WriteLine("tempo critico ");
                computerChoise = GetLosingMove(playerOption);
            }

            return computerChoise;
        }

        // =========================
        // 🔴 DIFÍCIL (INTELIGENTE)
        // =========================
        private static int GetHardMove(int playerOption, double choiseTime)
        {
            int computerChoise = 0;

            if (choiseTime <= 2)
            {
                Console.WriteLine("cedo");
                computerChoise = GetCounterMove(playerOption);
            }
            else if (choiseTime <= 2.8)
            {
                Console.WriteLine("tempo normal ");
                computerChoise = GetRandomMove();
            }
            else
            {
                Console.WriteLine("tempo critico ");
                computerChoise = GetLosingMove(playerOption);
            }

            return computerChoise;
        }

    }

    public class Probabilities
    {
        public double Win;     // CPU ganha
        public double Lose;    // CPU perde
        public double Random;  // aleatório
    }
}
