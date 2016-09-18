namespace GameEngine.Core
{
    using System;
    using System.Linq;

    using Characters;
    using Items;

    public class AdvancedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            base.ExecuteCommand(inputParams);
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItemToCharacter(inputParams);
                    break;
                default:
                    break;
            }
        }

        protected void CreateCharacter(string[] inputParams)
        {
            string characterType = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team) Enum.Parse(typeof (Team), inputParams[5]);
            Character character = CharacterFactory.Create(characterType, id, team, x, y);
            characterList.Add(character);
        }

        protected void AddItemToCharacter(string[] args)
        {
            string id = args[1];
            Character character = characterList.FirstOrDefault(ch => ch.Id == id);
            Item item = ItemFactory.Create(args[2], args[3]);
            character.AddToInventory(item);
        }
    }
}
