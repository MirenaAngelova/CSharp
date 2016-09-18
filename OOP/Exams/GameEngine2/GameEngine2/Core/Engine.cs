using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Characters;
using GameEngine2.Enum;
using GameEngine2.Interfaces;
using GameEngine2.Items;

namespace GameEngine2.Core
{
    public class Engine
    {
        private const int GameTurns = 4;

        protected List<Character> characterList = new List<Character>();
        protected List<Bonus> timeoutItems;

        public virtual void Run()
        {
            this.ReadUserInput();
            this.InitializeTimeoutItems();
            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in this.characterList)
                {
                    if (character.IsAlive)
                    {
                        this.ProcessTargetSearch(character);
                    }
                }

                this.ProcessItemTimeout(this.timeoutItems);
            }

            this.PrintGameOutcome();
        }

        protected void PrintGameOutcome()
        {
            var aliveCharacters = this.characterList.Where(ch => ch.IsAlive);
            var redTeamCount = aliveCharacters.Count(ch => ch.Team == Team.Red);
            var blueTeamCount = aliveCharacters.Count(ch => ch.Team == Team.Blue);

            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine($"{winningTeam} team wins the game!");
            }
        }

        public void ProcessItemTimeout(List<Bonus> timeoutItems)
        {
            for (int i = 0; i < timeoutItems.Count; i++)
            {
                timeoutItems[i].Countdown--;
                if (timeoutItems[i].Countdown == 0)
                {
                    var item = timeoutItems[i];
                    item.HasTimedOut = true;
                    var itemHolder = this.GetCharacterByItem(item);
                    itemHolder.RemoveFromInventory(item);
                    i--;
                }
            }
        }

        protected Character GetCharacterById(string chracterId)
        {
            return this.characterList.FirstOrDefault(ch => ch.Id == chracterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return this.characterList.FirstOrDefault(i => i.Inventory.Contains(item));
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTarget = this.characterList
                .Where(target => this.IsWithinTheRange(
                    currentCharacter.X,
                    currentCharacter.Y, 
                    target.X, target.Y, 
                    currentCharacter.Range))
                .ToList();
            if (availableTarget.Count == 0)
            {
                return;
            }

            var currentTarget = currentCharacter.GetTarget(availableTarget);
            if (currentTarget == null)
            {
                return;
            }

            this.ProcessInteraction(currentCharacter, currentTarget);
        }

        protected void ProcessInteraction(Character currentCharacter, Character currentTarget)
        {
            if (currentCharacter is IHeal)
            {
                currentTarget.HealthPoints += (currentCharacter as IHeal).HealingPoints;
            }
            else if (currentCharacter is IAttack)
            {
                currentTarget.HealthPoints -= (currentCharacter as IAttack).AttackPoints - currentTarget.DefensePoints;
                if (currentTarget.HealthPoints <= 0)
                {
                    currentTarget.IsAlive = false;
                }
            }
        }

        protected bool IsWithinTheRange(int attackerX, int attackerY, int targetX, int targetY, int attackerRange)
        {
            double distanceAttackerTarget = Math.Sqrt((attackerX - targetX)*(attackerX - targetX) -
                                     (attackerY - targetY)*(attackerY - targetY));
            return distanceAttackerTarget <= attackerRange;
        }

        public void InitializeTimeoutItems()
        {
            this.timeoutItems = this.characterList
                .SelectMany(ch => ch.Inventory)
                .Where(i => i is Bonus)
                .Cast<Bonus>()
                .ToList();
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != string.Empty)
            {
                string[] parameters = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                this.ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }

        protected virtual void ExecuteCommand(string[] parameters)
        {
            string command = parameters[0];
            switch (command.ToLower())
            {
                case "status":
                    this.PrintCharacterStatus(this.characterList);
                    break;
            }
        }

        protected void PrintCharacterStatus(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                Console.WriteLine(character.ToString());
            }
        }

        protected virtual void CreateCharacter(string[] inputParams)
        {
            throw new NotImplementedException();
        }

        protected void AddItem(string[] inputParams)
        {
            throw new NotImplementedException();
        }
    }
}
