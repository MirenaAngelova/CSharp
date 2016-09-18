using Empires6.Enums;

namespace Empires6.Constants
{
    public static class Constant
    {
        public const string ErrorAssemblyMessage = " The {0} cannot be found in current assembly.";

        public const string UnitsPropertyLength =
            "Units should have {0} {1} and at the time of their creation";

        public const string ResourcesPropertyLength =
            "The quantity of produced resources should be non-negative";
        
        public const string BeforeTurns =
            "{0} turns have passed, {1} cannot produce {2} yet - {3} turns must pass";

        public const string IndefinedCommand = "Indefined command";

        public const string NullException = "The {0} cannot be null.";

        public const string PropertyTurns = "The {0}'s turns should be positive.";

        public const int SwordsmanHealth = 40;

        public const int SwordsmanDamage = 13;

        public const int ArcherHealth = 25;

        public const int ArcherDamage = 7;

        public const int CreationDelay = 1;
        
        public const int BarracksQuantity = 10;

        public const ResourceType BarracksResourceType = ResourceType.Steel;

        public const int BarracksResourceTurns = 3;

        public const string BarracksUnit = "Swordsman";

        public const int BarracksUnitTurns = 4;
       
        public const int ArcheryQuantity = 5;

        public const ResourceType ArcheryResourceType = ResourceType.Gold;

        public const int ArcheryResourceTurns = 2;

        public const string ArcheryUnit = "Archer";

        public const int ArcheryUnitTurns = 3;
    }
}