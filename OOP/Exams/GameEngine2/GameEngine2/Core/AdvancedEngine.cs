using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Characters;
using GameEngine2.Enum;
using GameEngine2.Items;

namespace GameEngine2.Core
{ 
    public class AdvancedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParameters)
        {
            base.ExecuteCommand(inputParameters);
            string command = inputParameters[0];
            switch (command.ToLower())
            {
                case "create":
                    CreateCharacter(inputParameters);
                    break;
                case "add":
                    AddItemToCharacter(inputParameters);
                    break;
                default:
                    break;
            }
        }

        private void AddItemToCharacter(string[] inputParameters)
        {
            string idCharacter = inputParameters[1];
            Character character = characterList.FirstOrDefault(ch => ch.Id == idCharacter);

            string itemType = inputParameters[2];
            string idItem = inputParameters[3];
            Item item = ItemsFactory.Create(itemType, idItem);
            character.AddToInventory(item);
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string characterType = inputParams[1];
            string characterId = inputParams[2];
            int characterX = int.Parse(inputParams[3]);
            int characterY = int.Parse(inputParams[4]);
            Team characterTeam = (Team) System.Enum.Parse(typeof (Team), inputParams[5]);

            Character character = CharacterFactory.Create(
                characterType, 
                characterId, 
                characterTeam, 
                characterX,
                characterY);
            characterList.Add(character);
        }
    }
}
