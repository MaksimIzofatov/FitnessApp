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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Random r = new Random();

            var userController = new UserController(Guid.NewGuid().ToString());
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(Guid.NewGuid().ToString(), r.Next(10, 50));

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}