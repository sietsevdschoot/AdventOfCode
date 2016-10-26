using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    /// <summary>
    /// 
    /// --- Day 17: No Such Thing as Too Much ---
    /// 
    /// The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers.
    /// 
    /// For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:
    /// 
    /// 15 and 10
    /// 20 and 5 (the first 5)
    /// 20 and 5 (the second 5)
    /// 15, 5, and 5
    /// Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?
    /// 
    /// </summary>
    [TestClass]
    public class Day17
    {
        [TestMethod]
        public void Part1_TestCase1()
        {
            // Arrange
            var containers = new[] {20, 15, 10, 5, 5};

            // Act
            var actual = CalculateOptimalSolutions(containers: containers, litersToStore: 25);
            
            // Assert
            actual.Count().Should().Be(4);
        }

        private IEnumerable<int[]> CalculateOptimalSolutions(int[] containers, int litersToStore)
        {
            var sortedContainers = containers.OrderByDescending(x => x);

            var solutions = new List<int[]>();
            var usedContainers = new List<int>();

            
            foreach (var container in sortedContainers)
            {
                var remainder = litersToStore;

                                
                
            }
            

            throw new System.NotImplementedException();
        }

        private int[] FindSolution(int[] containers, int currentIndex, int litersToStore)
        {
            var usedContainers = new List<int>();
            
            for (int i = 0; i < containers.Length; i++)
            {
                if (i == currentIndex)
                {
                    continue;
                }

                var currentNumber = containers[i];
                


            }

            throw new NotImplementedException();

        }
    }
}