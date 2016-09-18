namespace ClashOfKings.Exeptions
{
    public class DuplicateCityException : GameExceptions
    {
        public DuplicateCityException(string message)
            : base(message)
        {
        }
    }
}
