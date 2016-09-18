namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendLine($"Student successfully enrolled in course {course.Name}.");
        }
    }
}