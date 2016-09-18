using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BuhtigIssueTracker2.Data;
using BuhtigIssueTracker2.Infrastructure;
using BuhtigIssueTracker2.Interfaces;
using BuhtigIssueTracker2.Stuff;
using BuhtigIssueTracker2.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BuhtigIssueTracker2.Tests
{
    [TestClass]
    public class RegisterUserTest
    {
        [TestMethod]
        public void RegisterUser_WithValidUser_ShouldReturnAppropriateMessage()
        {
            var issueTracker = new IssueTracker();
            var actual = issueTracker.RegisterUser("username", "password", "password");

            var expected = string.Format(Validation.MessageUserRegistredSuccessfully, "username");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RegisterUser_WithNoMatchPasswords_ShouldReturnAppropriateMessage()
        {
            var issueTracker = new IssueTracker();
            issueTracker.RegisterUser("username", "password", "passwor");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RegisterUser_WithNoMatchPasswords2_ShouldReturnAppropriateMessage()
        {
            var issueTracker = new IssueTracker();

            var actual = issueTracker.RegisterUser("username", "password", "passwor");

            var expected = Validation.MessagePasswordNotMatch;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegisterUser_WithAlreadyLoggedInUser_ShouldReturnAppropriateMessage()
        {
            var issueTracker = new IssueTracker();
            string username = "username";
            issueTracker.RegisterUser(username, "password", "password");
            var actual = issueTracker.LoginUser(username, "password");

            var expected = Validation.MessageAlreadyLoggedInUser;

            Assert.AreEqual(expected, actual, "Didn't return: There is already a logged in user");
        }

        [TestMethod]
        public void RegisterUser_WithAlreadyExistsUser_ShouldReturnAppropriateMessage()
        {
            var issueTracker = new IssueTracker();
            string username = "username";
            issueTracker.RegisterUser(username, "password", "password");

            var actual = issueTracker.RegisterUser(username, "password", "password");

            var expected = string.Format(Validation.MessageUserExists, username);

            Assert.AreEqual(expected, actual, "Didn't return:A user with username username already exists");
        }

        [TestMethod]
        public void RegisterUser_WithValidUser_ShouldAddEntryToUserDatabase()
        {
            var mockData = new Mock<IBuhtigIssueTrackerData>();
            var mockDictionary = new Mock<IDictionary<string, User>>();
            mockData.Setup(m => m.Users).Returns(mockDictionary.Object);

            var username = "username";
            var password = "password";
            var database = mockData.Object;
            var issueTracker = new IssueTracker(database);

            issueTracker.RegisterUser(username, password, password);

            mockDictionary.Verify(d => d.Add(It.IsAny<string>(), It.IsAny<User>()), Times.Exactly(1));
        }

        [TestMethod]
        public void RegisterUser_ShouldAddAnEntryWithTheCorrectKeyAndValueToTheCollection()
        {
            var mock = new Mock<IBuhtigIssueTrackerData>();
            var mockDictionary = new Mock<IDictionary<string, User>>();

            string expectedUsername = null;
            User expectedUser = null;
            mockDictionary.Setup(d => d.Add(It.IsAny<string>(), It.IsAny<User>()))
                .Callback<string, User>(
                    (name, user) =>
                    {
                        expectedUsername = name;
                        expectedUser = user;
                    });

            mock.Setup(d => d.Users).Returns(mockDictionary.Object);

            var username = "Name";
            var password = "Password";
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.RegisterUser(username, password, password);

            Assert.AreEqual(expectedUsername, username);
            Assert.AreEqual(expectedUser.Username, username);
            Assert.AreEqual(expectedUser.PasswordHash, User.HashPassword(password));
        }
    }
}