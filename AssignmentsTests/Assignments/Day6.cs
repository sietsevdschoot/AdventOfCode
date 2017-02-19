using System;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using AssignmentsTests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        public void ParseInstruction_Should_Parse_Turn_On_correctly()
        {
            LightInstruction.Create("turn on 100,101 through 200,202")
                            .Switch.Should().Be(Switch.On);
        }

        [TestMethod]
        public void ParseInstruction_Should_Parse_Turn_Off_correctly()
        {
            LightInstruction.Create("turn off 100,101 through 200,202")
                            .Switch.Should().Be(Switch.Off);
        }

        [TestMethod]
        public void ParseInstruction_Should_Parse_Toggle_correctly()
        {
            LightInstruction.Create("toggle 100,101 through 200,202")
                            .Switch.Should().Be(Switch.Toggle);
        }

        [TestMethod]
        public void ParseInstruction_Parses_Instruction_Correctly()
        {
            // Arrange
            var expected = new LightInstruction
            {
                Start = new Point(100, 101),
                End = new Point(200, 202),
                Switch = Switch.Off
            };

            // Act
            var actual = LightInstruction.Create("turn off 100,101 through 200,202");

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GetLightStatus_Returns_new_lightStatus()
        {
            // Arrange
            var grid = new Grid();

            // Assert
            grid.GetLightStatus(previousStatus: false, switchAction: Switch.On).Should().BeTrue();
            grid.GetLightStatus(previousStatus: true, switchAction: Switch.Off).Should().BeFalse();
            grid.GetLightStatus(previousStatus: true, switchAction: Switch.Toggle).Should().BeFalse();
        }

        [TestMethod]
        public void Part1_TestCase1()
        {
            // Arrange
            var grid = new Grid();

            // Act
            grid.Execute(LightInstruction.Create("turn on 0,0 through 999,999"));

            // Assert
            grid.GetTurnedOnLights().Should().Be(1000 * 1000);
        }

        [TestMethod]
        public void Solve_Part1()
        {
            var grid = new Grid();

            Files.Day6.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList()
                      .ForEach(x => grid.Execute(LightInstruction.Create(x)));

            Console.WriteLine(grid.GetTurnedOnLights());        
        }

    }

}