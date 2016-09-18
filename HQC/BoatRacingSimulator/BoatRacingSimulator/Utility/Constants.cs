namespace BoatRacingSimulator.Utility
{
    public static class Constants
    {
        public const string IncorrectModelLenghtMessage = "Model's name must be at least {0} symbols long.";

        public const string IncorrectPropertyValueMessage = "{0} must be a positive integer.";

        public const string IncorrectSailEfficiencyMessage = "Sail Effectiveness must be between [1...100].";

        public const string IncorrectEngineTypeMessage = "Incorrect engine type.";

        public const string DuplicateModelMessage = "An entry for the given model already exists.";

        public const string NonExistantModelMessage = "The specified model does not exist.";

        public const string RaceAlreadyExistsMessage = "The current race has already been set.";

        public const string NoSetRaceMessage = "There is currently no race set.";

        public const string InsufficientContestantsMessage = "Not enough contestants for the race.";

        public const string IncorrectBoatTypeMessage = 
            "The specified boat does not meet the race constraints.";

        public const string EngineCreatedSuccessfully =
            "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.";

        public const string BoatRegisteredSuccessfully =
            "{0} boat with model {1} registered successfully.";

        public const string NewRaceSet =
            "A new race with distance {0} meters," +
            " wind speed {1} m/s and ocean current speed {2} m/s has been set.";

        public const string BoatSignedUp = "Boat with model {0} has signed up for the current Race.";

        public const string InvalidCommand = "InvalidCommand";

        public const int MinBoatModelLength = 5;

        public const int MinBoatEngineModelLength = 3;

        public const int SterndriveEngineMultiplier = 7;

        public const int JetEngineMultiplier = 5;

        public const int MinParticipantsCount = 3;

    }
}
