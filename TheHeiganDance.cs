using System;

namespace _20.The_Heigan_Dance
{
    public class TheHeiganDance
    {
        private const int ChamberRows = 15;
        private const int ChamberCols = 15;
        private const int PlayerStartRow = ChamberRows / 2;
        private const int PlayerStartCol = ChamberCols / 2;
        private const int Radius = 1;
        private const double PlayerHitPoints = 18500;
        private const double HeiganHitPoints = 3000000;
        private static int cloudActionsCount = 2;

        private static Player player;
        private static Heigan heigan;

        private static int cloudTurns;
        private static int cloudsCount;
        private static double damageToHeigan;
        private static double damageToPlayer;

        private static int lowerRowBound;
        private static int upperRowBound;
        private static int lowerColBound;
        private static int upperColBound;

        public static void Main()
        {
            damageToHeigan = double.Parse(Console.ReadLine());
            player = new Player(PlayerHitPoints, PlayerStartRow, PlayerStartCol, damageToHeigan);
            heigan = new Heigan(HeiganHitPoints, damageToPlayer);
           

            while (true)
            {
                ApplyDamageToHeigan();
                CheckHeiganDeath();

                string[] paramArgs = Console.ReadLine().Split();
                //Enum spell = (Spell)Enum.Parse(typeof(Spell), paramArgs[0]);
                string spell = paramArgs[0];
                InitializeSpell(spell);

                int hitRow = int.Parse(paramArgs[1]);
                int hitCol = int.Parse(paramArgs[2]);
                DamagedArea(hitRow, hitCol);

                if (IsDamagedCell(player.Row, player.Col))
                {
                    if (player.Row - 1 >= 0 && !IsDamagedCell(player.Row - 1, player.Col))
                    {
                        player.Row--;
                        cloudsCount = 0;
                    }
                    else if (player.Col + 1 < ChamberCols && !IsDamagedCell(player.Row, player.Col + 1))
                    {
                        player.Col++;
                        cloudsCount = 0;
                    }
                    else if (player.Row + 1 < ChamberRows && !IsDamagedCell(player.Row + 1, player.Col))
                    {
                        player.Row++;
                        cloudsCount = 0;
                    }
                    else if (player.Col - 1 >= 0 && !IsDamagedCell(player.Row, player.Col - 1))
                    {
                        player.Col--;
                        cloudsCount = 0;
                    }
                    else
                    {
                        if (spell == "Eruption")
                        {
                            DecreaseCloudTurns();
                            player.HitPoints -= damageToPlayer;
                            CheckPlayerDeath(spell);
                        }
                        else
                        {
                            DecreaseCloudTurns();
                            CheckPlayerDeath(spell);
                        }
                    }
                }
            }
        }

        private static void DamagedArea(int hitRow, int hitCol)
        {
            lowerRowBound = Math.Max(hitRow - Radius, 0);
            upperRowBound = Math.Min(hitRow + Radius, ChamberRows - 1);
            lowerColBound = Math.Max(hitCol - Radius, 0);
            upperColBound = Math.Min(hitCol + Radius, ChamberCols - 1);
        }

        private static bool IsDamagedCell(int row, int col)
        {
            return row >= lowerRowBound && row <= upperRowBound &&
                    col >= lowerColBound && col <= upperColBound;
        }

        private static void CheckPlayerDeath(string spell)
        {
            if (player.HitPoints <= 0)
            {
                Console.WriteLine($"Heigan: {heigan.HitPoints:F2}");
                if(spell == "Cloud")
                {
                    Console.WriteLine($"Player: Killed by Plague {spell}");
                }
                else
                {
                    Console.WriteLine($"Player: Killed by {spell}");
                }
                
                Console.WriteLine($"Final position: {player.Row}, {player.Col}");
                Environment.Exit(0);
            }
        }

        private static void InitializeSpell(string spell)
        {
            if (spell == "Cloud")
            {
                damageToPlayer = (double)Spell.Cloud;
                cloudTurns += cloudActionsCount;
                cloudsCount++;
            }
            else
            {
                damageToPlayer = (double)Spell.Eruption;
            }
        }

        private static void CheckHeiganDeath()
        {
            if (heigan.HitPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {player.HitPoints}");
                Console.WriteLine($"Final position: {player.Row}, {player.Col}");
                Environment.Exit(0);
            }
        }

        private static void ApplyDamageToHeigan()
        {
            heigan.HitPoints -= player.DamageToHeigan;
        }

        private static void DecreaseCloudTurns()
        {
            if (cloudsCount > 0)
            {
                player.HitPoints -= (double)Spell.Cloud * cloudsCount;
                CheckPlayerDeath("Cloud");
                cloudTurns--;
                if (cloudTurns % cloudActionsCount == 0)
                {
                    cloudsCount--;
                    cloudTurns = cloudsCount == 0 ? 0 : cloudTurns - (cloudActionsCount - 1);
                }
            }
        }

        public class Player
        {
            public Player(double hitPoints, int row, int col, double damageToHeigan)
            {
                this.HitPoints = hitPoints;
                this.Row = row;
                this.Col = col;
                this.DamageToHeigan = damageToHeigan;
            }

            public double DamageToHeigan { get; set; }

            public int Col { get; set; }

            public int Row { get; set; }

            public double HitPoints { get; set; }
        }

        public class Heigan
        {
            public Heigan(double hitPoints, double damageToPlayer)
            {
                this.HitPoints = hitPoints;
                this.DamageToPlayer = damageToPlayer;
            }

            public double DamageToPlayer { get; set; }

            public double HitPoints { get; set; }
        }

        public enum Spell
        {
            Cloud = 3500,
            Eruption = 6000
        }
    }
}
