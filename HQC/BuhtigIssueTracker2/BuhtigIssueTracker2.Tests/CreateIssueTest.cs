using System;
using BuhtigIssueTracker2.Infrastructure;
using BuhtigIssueTracker2.Interfaces;
using BuhtigIssueTracker2.Stuff;
using BuhtigIssueTracker2.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BuhtigIssueTracker2.Tests
{
    [TestClass]
    public class CreateIssueTest
    {
        private IssueTracker issueTracker;

        [TestInitialize]
        public void IssueTracker()
        {
            this.issueTracker = new IssueTracker();
        }

        [TestMethod]
        public void CreateIssue_WithValidInput_ShouldReturnAppropriateMessage()
        {
            this.issueTracker.RegisterUser("username", "password", "password");
            this.issueTracker.LoginUser("username", "password");

            var actual = this.issueTracker.CreateIssue(
                "title", "description", PriorityIssue.High, new[] {"issue", "new"});

            var expected = string.Format(Validation.MessageIssueCreatedSuccessfully, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateIssue_WithNoLoggedInUser_ShouldReturnAppropriateMessage()
        {
            this.issueTracker.RegisterUser("username", "password", "password");
 
            var actual = this.issueTracker.CreateIssue(
                "title", "description", PriorityIssue.High, new[] { "issue", "new" });

            var expected = Validation.MessageNoLoggedInUser;

            Assert.AreEqual(expected, actual, "Did not return a Issue created succesfully message.");
        }

        [TestMethod]
        public void CreateIssue_WithValidInput_ShouldCallDatabaseAddIssueMethod()
        {
            var mockData = new Mock<IBuhtigIssueTrackerData>();
            mockData.SetupProperty(u => u.CurrentUser, new User("username", "password"));

            var title = "title";
            var description = "description";
            var priority = PriorityIssue.High;
            var strings =new string[] {"issue", "new"};
            this.issueTracker.CreateIssue(title, description, priority, strings);

            mockData.Verify(d => d.AddIssue(It.IsAny<Issue>()), Times.Exactly(1));
        }

        [TestMethod]
        public void CreateIssue_WithValidInput_ShouldSendIssueToDatabase()
        {
            
        }
    }
}
