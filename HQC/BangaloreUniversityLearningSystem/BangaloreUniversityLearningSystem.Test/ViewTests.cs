using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversityLearningSystem.Test
{
    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void Display_ShouldReturnStringResult()
        {
            var test = "Test";
            var createView = new MockView(test);

            var result = createView.Display();

            Assert.IsInstanceOfType(result, typeof (string));
        }

        [TestMethod]
        public void Display_ShouldReturnCorrectResult()
        {
            var test = "Test";
            var createView = new MockView(test);

            var result = createView.Display();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void Disply_ShouldTrimResult()
        {
            var test = "Test ";
            var createView = new MockView(test);

            var result = createView.Display();

            Assert.AreEqual("Test", result);
        }
    }
}

