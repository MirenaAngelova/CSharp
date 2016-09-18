namespace GameEngine.Interfaces
{
    public interface ITimeoutable
    {
        int Timeout { get; set; } 
         
        int Countdown { get; set; }

        bool HasTimeOut { get; set; }
    }
}