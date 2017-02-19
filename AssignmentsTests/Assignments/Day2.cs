using System;
using System.Linq;
using AssignmentsTests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        public void Solve()
        {
            var lines = Files.Day2.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(CalculateWrappingPaper(lines));
        }

        [TestMethod]
        public void Solve_Part2()
        {
            var lines = Files.Day2.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(CalculateRibbon(lines));
        }

        [TestMethod]
        public void WrappingPaper_TestCase1()
        {
            CalculateWrappingPaper("2x3x4").Should().Be(58);
        }

        [TestMethod]
        public void CalculateRibbon_TestCase1()
        {
            CalculateRibbon("2x3x4").Should().Be(34);
        }
        
        private int CalculateWrappingPaper(params string[] lines)
        {
            return Calculate((l, w, h) => (2*l*w) + (2*w*h) + (2*h*l) + (new[] {l*w, w*h, h*l}.Min()), lines);
        }

        private int CalculateRibbon(params string[] lines)
        {
            return Calculate((l, w, h) => (l * w * h) + (new[] { 2 * l + 2 * w, 2 * w + 2 * h, 2 * h + 2 * l }.Min()), lines);
        }

        private int Calculate(Func<int, int, int, int> formula, params string[] lines)
        {
            return lines.Select(line =>
            {
                var amounts = line.Split('x').Select(int.Parse).ToList();
                return formula(amounts[0], amounts[1], amounts[2]);
            })
            .Sum();
        }
    }
}