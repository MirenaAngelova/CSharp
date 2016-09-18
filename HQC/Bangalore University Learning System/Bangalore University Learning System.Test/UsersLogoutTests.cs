namespace Bangalore_University_Learning_System.Test
{
    using System;

    using Controllers;
    using Core.Interfaces;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersLogoutTests
    {
        private IBangaloreUniversityData data;
        private UsersController usersController;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUsersLogoutWithNullUser()
        {
            this.data = new BangaloreUniversityData();
            this.usersController = new UsersController(this.data, null);
            this.usersController.Logout();
        }
    }
}
