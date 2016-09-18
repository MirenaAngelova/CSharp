namespace BangaloreUniversityLearningSystem.Models
{
    using Utilities;

    public class Lecture
    {
        private string lectureName;

        public Lecture(string lectureName)
        {
            // BUG this.Name = Name refactor to this.Name = name
            this.LectureName = lectureName;
        }

        public string LectureName
        {
            get
            {
                return this.lectureName;
            }

            private set
            {
                // Performance: Move validations to class Validator
                Validator.ValidateMinLength(value, Validation.MinLengthLectureName, "lecture name");
                this.lectureName = value;
            }
        }
    }
}