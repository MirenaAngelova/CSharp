namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;

    using Infrastructure;
    using Models;
    // BUG: Refactor AddLectures to AddLecture, cause of reflaction
    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendLine($"Lecture successfully added to course {course.Name}.");
        }
    }
}