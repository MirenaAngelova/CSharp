namespace Bangalore_University_Learning_System.Test
{
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void TestGetWithEmptyRepository()
        {
            int expectedResult = default(int);
            var repository = new Repository<int>();
            var actualResult = repository.Get(0);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetWithEmptyRepository2()
        {
            int input = It.IsAny<int>();
            int expectedResult = default(int);
            var repository = new Repository<int>();
            var actualResult = repository.Get(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetWithNoEmptyRepository2()
        {
            int input = It.IsAny<int>();
            var repository = new Repository<int>();
            repository.Add(input);
            var actualResult = repository.Get(1);
            Assert.AreEqual(input, actualResult);
        }

        [TestMethod]
        public void TestGetWithRefType()
        {
            string input = It.IsAny<string>();
            var repository = new Repository<string>();
            repository.Add(input);
            var actualResult = repository.Get(1);
            Assert.AreEqual(input, actualResult);
            Assert.AreSame(input, actualResult);
        }

        [TestMethod]
        public void TestGetWithManyItems()
        {
            int input = It.IsAny<int>();
            int input1 = It.IsAny<int>();
            int input2 = It.IsAny<int>();
            var repository = new Repository<int>();
            repository.Add(input);
            repository.Add(input1);
            repository.Add(input2);
            var actualResult = repository.Get(2);
            Assert.AreEqual(input2, actualResult);
        }
    }
}
