namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendLine($"Course {course.Name} created successfully.");
        }
    }
}