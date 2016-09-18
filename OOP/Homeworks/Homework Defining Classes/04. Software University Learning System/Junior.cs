
namespace _04.Software_University_Learning_System
{
    public class Junior : Trainer
    {
        public Junior(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
