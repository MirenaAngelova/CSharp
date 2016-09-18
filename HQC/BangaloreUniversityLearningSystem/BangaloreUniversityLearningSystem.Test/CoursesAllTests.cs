namespace BangaloreUniversityLearningSystem.Test
{
    using System;
    using System.Collections.Generic;

    using Controllers;
    using Interfaces;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CoursesAllTests
    {
        [TestMethod]
        public void All_WithValidData_ShouldCallDataToGetAll()
        {
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.GetAll()).Returns(new List<Course>());
            var coursesControler = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));

            coursesControler.All();

            data.Verify(d => d.Courses.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void All_ShouldReturnIViewObject()
        {
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.GetAll()).Returns(new List<Course>());
            var coursesController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));

            var result = coursesController.All();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        [TestMethod]
        public void All_WithoutCurrentUser_ShouldReturnIViewObject()
        {
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.GetAll()).Returns(new List<Course>());
            var coursesController = new CoursesController(data.Object, null);

            var result = coursesController.All();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldCallDataCoursesGetMethod()
        {
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(new Course("course name"));
            var coursesController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));

            var result = coursesController.AddLecture(1, "lecture name");

            data.Verify(d => d.Courses.Get(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldAddNewLectureToSpecifiedCourse()
        {
            var data = new Mock<IBangaloreUniversityData>();
            var course = new Course("course name");
            data.Setup(d => d.Courses.Get(It.IsAny<int>())).Returns(course);

            Assert.AreEqual(0, course.Lectures.Count);

            var coursesController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));
            coursesController.AddLecture(2, "lecture name");

            Assert.AreEqual(1, course.Lectures.Count);
        }

        [TestMethod]
        public void AddLecture_WitValidInput_ShouldReturnNameOfLecture()
        {
            var course = new Course("course name");

            Assert.AreEqual(0, course.Lectures.Count);

            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));
      
            courseController.AddLecture(1, "lecture name");
            Assert.AreEqual("lecture name", course.Lectures[0].LectureName);
        }

        [TestMethod]
        public void AddLecture_WithNoLoggedInUser_ShouldReturnAppropriateExceptionMessage()
        {
            var course = new Course("course name");
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(course);

            var coursesController = new CoursesController(data.Object, null);

            var exception = string.Empty;

            try
            {
                coursesController.AddLecture(1, "lecture name");
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            var expected = "There is no currently logged in user.";

            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public void AddLecture_WithNoAuthorizedUserToPerformAction_ShouldReturnAppropriateExceptionMessage()
        {
            var course = new Course("course name");
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(course);

            var coursesController = new CoursesController(data.Object,
                new User("user name", "password", Role.Student));

            var exception = string.Empty;
            try
            {
                coursesController.AddLecture(1, "lecture name");
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            var expected = "The current user is not authorized to perform this operation.";

            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public void AddLecture_WithNonExistingCourse_ShouldReturnAppropriateExceptionMessage()
        {
            Course course = null;
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(course);

            var coursesController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));

            var exception = string.Empty;
            try
            {
                coursesController.AddLecture(1, "lecture name");
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            var expected = "There is no course with ID 1.";

            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldReturnIViewObject()
        {
            var course = new Course("course name");
            
            var data = new Mock<IBangaloreUniversityData>();
            data.Setup(c => c.Courses.Get(It.IsAny<int>())).Returns(course);
            var coursesController = new CoursesController(data.Object, 
                new User("user name", "password", Role.Lecturer));

            var result  = coursesController.AddLecture(1, "lecture name");

            Assert.IsInstanceOfType(result, typeof(IView));
        }
    }
}
