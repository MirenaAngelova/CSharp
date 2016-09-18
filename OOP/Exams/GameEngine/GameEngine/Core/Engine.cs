namespace GameEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Characters;
    using Interfaces;
    using Items;

    public class Engine
    {
        protected List<Character> characterList = new List<Character>();
        protected List<Bonus> timeoutItems;

        private const int GameTurns = 4;

        public virtual void Run()
        {
            this.ReadUserInput();
            this.InitializeTimeoutItems();
            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in characterList)
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
            var charactersAlive = this.characterList.Where(ch => ch.IsAlive);
            var redTeamCount = this.characterList.Count(ch => ch.Team == Team.Red);
            var blueTeamCount = this.characterList.Count(ch => ch.Team == Team.Blue);
            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine(winningTeam + " team wins the game!");
            }

            this.PrintCharacterStatus(charactersAlive);
        }

        private void ProcessItemTimeout(List<Bonus> timeoutItems)
        {
            for (int i = 0; i < timeoutItems.Count; i++)
            {
                timeoutItems[i].Countdown--;
                if (timeoutItems[i].Countdown == 0)
                {
                    var item = timeoutItems[i];
                    item.HasTimeOut = true;
                    var itemHolder = this.GetCharacterByItem(item);
                    itemHolder.RemoveFromInventory(item);
                    i--;
                }
            }
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTargets = this.characterList
                .Where(t => this.IsWithinRange(currentCharacter.X, currentCharacter.Y, t.X, t.Y, currentCharacter.Range))
                .ToList();
            if (availableTargets.Count == 0)
            {
                return;
            }

            var target = currentCharacter.GetTarget(availableTargets);
            if (target == null)
            {
                return;
            }

            this.ProcessInteraction(currentCharacter, target);
        }

        protected void ProcessInteraction(Character currentCharacter, Character target)
        {
            if (currentCharacter is IHeal)
            {
                target.HealthPoints += (currentCharacter as IHeal).HealingPoints;
            }
            else if (currentCharacter is IAttack)
            {
                target.HealthPoints -= (currentCharacter as IAttack).AttackPoints - target.DefensePoints;
            }

            if (target.HealthPoints <= 0)
            {
                target.IsAlive = false;
            }
        }

        public void InitializeTimeoutItems()
        {
            this.timeoutItems =
                this.characterList
                .SelectMany(c => c.Inventory)
                .Where(i => i is Bonus)
                .Cast<Bonus>()
                .ToList();
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != String.Empty)
            {
                string[] parameters = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }

        protected virtual void ExecuteCommand(string[] inputParams)
        {
            string command = inputParams[0];
            switch (command)
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

        protected bool IsWithinRange(int attackerX, int attackerY, int targetX, int targetY, int range)
        {
            double distance = Math.Sqrt((attackerX - targetX) * (attackerX - targetX) +
                                        (attackerY - targetY) * (attackerY - targetY));
            return distance <= range;
        }

        protected Character GetCharacterById(string characterId)
        {
            return this.characterList.FirstOrDefault(ch => ch.Id == characterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return this.characterList.FirstOrDefault(i => i.Inventory.Contains(item));
        }
    }
}
