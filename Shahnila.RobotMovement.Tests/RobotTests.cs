using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Shahnila.RobotMovement.Math;
using Shahnila.RobotMovement;

namespace Shahnila.RobotMovement.Tests
{
  
    [TestClass]
    public class RobotTests
    {
        //Verify that the robot's initial position is correct.
        [TestMethod]
        public void TestRobotCreation()
        {
            Robot robot = new Robot(new Vector2(10, 11));

            Assert.AreEqual(10, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);
        }

       //***********Track Robot Movement by entering X Cordinate and Y Cordinate from some textbox
        [TestMethod]
        public void TestRobotMove()
        {
            Robot robot = new Robot(new Vector2(10, 11));

            robot.Move(new Vector2(10, 0));
            Assert.AreEqual(20, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);

            robot.Move(new Vector2(0, 11));
            Assert.AreEqual(20, robot.Position.X);
            Assert.AreEqual(22, robot.Position.Y);

            robot.Move(new Vector2(-10, -11));
            Assert.AreEqual(10, robot.Position.X);
            Assert.AreEqual(11, robot.Position.Y);
        }
       
    }
}
