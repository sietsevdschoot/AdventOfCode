using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AssignmentsTests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        public void Solve()
        {
            Console.WriteLine(GetNrOfHouses(Files.Day3));
        }

        [TestMethod]
        public void Solve_Part2()
        {
            Console.WriteLine(GetNrOfHousesForPart2(Files.Day3));
        }

        private int GetNrOfHousesForPart2(string directions)
        {
            var visitedBySanta = string.Join("", directions.Where((x, i) => i % 2 == 0));
            var visitedByRoboSanta = string.Join("", directions.Where((x, i) => i % 2 != 0));

            var houses = new[] {new Point(0,0) }
                .Concat(GetNrOfHouses(visitedBySanta)
                .Concat(GetNrOfHouses(visitedByRoboSanta)))
                .Distinct();

            return houses.Count();
        }

        private List<Point> GetNrOfHouses(string directions)
        {
            int x = 0;
            int y = 0;

            var directionsLookup = new Dictionary<char, Func<Point>>
            {
                {'>', () => new Point(++x, y)},                     
                {'<', () => new Point(--x, y)},                     
                {'v', () => new Point(x, ++y)},                     
                {'^', () => new Point(x, --y)},                     
            };

            return directions
                .Select(direction => directionsLookup[direction]())
                .GroupBy(house => house)
                .Select(house => house.Key)
                .ToList();
        }

        [TestMethod]
        public void Part2_TestCase_1()
        {
            GetNrOfHousesForPart2("^v").Should().Be(3);
        }

        [TestMethod]
        public void Part2_TestCase_2()
        {
            GetNrOfHousesForPart2("^>v<").Should().Be(3);
        }

        [TestMethod]
        public void Part2_TestCase_3()
        {
            GetNrOfHousesForPart2("^v^v^v^v^v").Should().Be(11);
        }
    }
}