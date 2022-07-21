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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            Random r = new Random();

            var userController = new UserController(Guid.NewGuid().ToString());
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(Guid.NewGuid().ToString(), r.Next(50, 500), r.Next(50, 500), r.Next(50, 500), r.Next(50, 500));

            //Act
            eatingController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
            //Assert.AreEqual()
        }
    }
}