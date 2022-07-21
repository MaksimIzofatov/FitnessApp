using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessAppBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAppBL.Model;

namespace FitnessAppBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDay = DateTime.Now.AddYears(-18);
            string gender = "men";
            double w = 90;
            double g = 190;
            var controller = new UserController(userName);

            controller.SetUserData(gender, birthDay, w, g);

            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();

            //Act
            var userController = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}