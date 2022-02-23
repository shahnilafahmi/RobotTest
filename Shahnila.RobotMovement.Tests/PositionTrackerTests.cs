using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shahnila.RobotMovement;

using Shahnila.RobotMovement.Math;

namespace Shahnila.RobotMovement.Tests
{
   
    [TestClass]
    public class PositionTrackerTests
    {
        // Verify that the position tracker's initial calculation works for
        [TestMethod]
        public void TestPositionTrackerCreation()
        {
            Robot robot = new Robot(new Vector2(10, 10));
            PositionTracker tracker = new PositionTracker(robot);
            
            Assert.AreEqual(1, tracker.CalculatePositionsVisited());
        }

        //Verify that starting in the positive grid works.
        [TestMethod]
        public void TestPositionTrackerCalculationPositiveStart()
        {
            Robot robot = new Robot(new Vector2(10, 10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(2, 0));
            robot.Move(new Vector2(0, 2));
            robot.Move(new Vector2(-2, 0));
            robot.Move(new Vector2(0, -2));

            Assert.AreEqual(8, tracker.CalculatePositionsVisited());
        }

        //Verify that starting in the negative grid works.
        [TestMethod]
        public void TestPositionTrackerCalculationNegativeStart()
        {
            Robot robot = new Robot(new Vector2(-10, -10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(2, 0));
            robot.Move(new Vector2(0, 2));
            robot.Move(new Vector2(-2, 0));
            robot.Move(new Vector2(0, -2));

            Assert.AreEqual(8, tracker.CalculatePositionsVisited());
        }

        //Verify that retracing your steps calculates the correct value.
        [TestMethod]
        public void TestRetraceSteps()
        {
            Robot robot = new Robot(new Vector2(-10, -10));
            PositionTracker tracker = new PositionTracker(robot);

            robot.Move(new Vector2(10, 0));
            robot.Move(new Vector2(-11, 0));

            Assert.AreEqual(12, tracker.CalculatePositionsVisited());
        }
    }
}
