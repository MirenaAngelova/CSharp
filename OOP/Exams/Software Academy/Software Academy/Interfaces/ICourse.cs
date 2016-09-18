namespace Software_Academy.Interfaces
{
    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString(); 
    }
}