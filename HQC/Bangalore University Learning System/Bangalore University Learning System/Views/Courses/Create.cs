namespace Bangalore_University_Learning_System.Views.Courses
{
    using System.Text;

    using Models;
    using Infrastructure;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}