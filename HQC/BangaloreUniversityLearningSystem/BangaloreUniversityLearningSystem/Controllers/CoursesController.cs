namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user) : base(data, user)
        {
        }

        public IView All()
        {
            // PERFORMNCE: Assign to variable courses.
            var courses = Data.Courses.GetAll().OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count);
            return this.View(courses);
        }

        public IView Details(int courseId)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageNoLoggedInUser);
            }

            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = Data.Courses.Get(courseId);
            Validator.ValidateNoCourse(course, courseId);

            if (!this.User.Courses.Contains(course))
            {
                throw new ArgumentException(Messages.ExceptionMessageNotEnrolled);
            }

            return this.View(course);
        }

        // BUG: Refactor int id to int courseId, cause of reflection
        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
          
            var course = Data.Courses.Get(courseId);
            Validator.ValidateNoCourse(course, courseId);

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException(Messages.ExceptionMessageAlreadyEnrolled);
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        // BUG: Refactor int c_id to int courseId, cause of reflection 
        public Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            Validator.ValidateNoCourse(course, courseId);

            return course;
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageNoLoggedInUser);
            }

            // BUG: this.User.IsInRole(Role.Lecturer) should be !this.User.IsInRole(Role.Lecturer)
            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException(Messages.ExceptionMessageNotAuthorized);
            }

            var course = new Course(name);
            Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageNoLoggedInUser);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException(Messages.ExceptionMessageNotAuthorized);
            }

            Course course = this.CourseGetter(courseId);
            // BUG: Remove quotes in course.AddLecture(new Lecture("lectureName"));
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }
    }
}
