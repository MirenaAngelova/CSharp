namespace Bangalore_University_Learning_System.Models
{
    using Utilities;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validation.ForMinLength(value, ValidationConstants.MinLectureNameLength, "lecture name");

                this.name = value;
            }
        }
    }
}