using System;
using System.Linq;
using AssignmentsTests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        public void Solve()
        {
            var answer = Files.Day1.Select(x => x == '(' ? 1 : -1).Sum();

            Console.Write(answer);
        }

        [TestMethod]
        public void Solve_Part2()
        {
            int floor = 0;

            var answer = Files.Day1.TakeWhile((x, i) =>
            {
                floor += x == '(' ? 1 : -1;
                return floor != -1;
            })
            .Count() + 1;
    
            Console.WriteLine(answer);
        }


    }
}