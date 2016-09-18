
namespace _01.Human__Student_and_Worker
{
    public class Student : Human
    {
        public string FacultyNum { get; set; }

        public Student(string firstName, string lastName, string facultyNum) : base(firstName, lastName)
        {
            this.FacultyNum = facultyNum;
        }
    }
}
