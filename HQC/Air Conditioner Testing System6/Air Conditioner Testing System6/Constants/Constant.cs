namespace Air_Conditioner_Testing_System6.Constants
{
    public static class Constant
    {
        public const string IncorrectPropertyLength = "{0}'s name must be at least {1} symbols long.";

        public const string NonReports = "No reports.";

        public const string InvalidCommand = "Invalid command";

        public const string Satus = "Jobs complete: {0:F2}%";

        public const string IncorrectRating = "Energy efficiency rating must be between \"A\" and \"E\".";

        public const string NonPositive = "{0} must be a positive integer.";

        public const string DuplicateEntry = "An entry for the given model already exists.";

        public const string NonExist = "The specified entry does not exist.";

        public const string RegisterSuccessfully = "Air Conditioner model {0} from {1} registered successfully.";

        public const string TestedSuccessfully = "Air Conditioner model {0} from {1} tested successfully.";

        public const int ModelMinLength = 2;

        public const int ManufacturerMinLength = 4;

        public const int MinCarVolume = 3;

        public const int MinPlaneElectricity = 150;

        public const int RegisterStationaryParametersCount = 4;

        public const int RegisterCarParametersCount = 3;

        public const int RegisterPlaneParametersCount = 4;

        public const int TestParametersCount = 2;

        public const int FindConditionerParametersCount = 2;

        public const int FindReportParametersCount = 2;

        public const int FindAllReportsParametersCount = 1;

        public const int StatusParametersCount = 0;




    }
}
