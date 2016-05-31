using System;
using System.Linq;
using System.Text.RegularExpressions;
using AssignmentsTests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day5
    {
        private static readonly Regex HasTwoRepeatingCharacters = new Regex(@"(.)\1{1}");
        private static readonly Regex HasTwoLetterRepetition = new Regex(@"^(.{2}).*\1");
        private static readonly Regex HasRepeatingCharacterWithOneLetterInBetween = new Regex(@"(.{1}).{1}\1.*$");
        
        [TestMethod]
        public void Solve()
        {
            var answer = Files.Day5.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Count(IsNiceString);

            Console.WriteLine(answer);
        }

        [TestMethod]
        public void Solve_Part2()
        {
            var answer = Files.Day5.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Count(IsNiceStringPartTwo);

            Console.WriteLine(answer);
        }

        [TestMethod]
        public void Part1_TestCases()
        {
            IsNiceString("ugknbfddgicrmopn").Should().BeTrue();
            IsNiceString("aaa").Should().BeTrue();
            
            IsNiceString("jchzalrnumimnmhp").Should().BeFalse();
            IsNiceString("haegwjzuvuyypxyu").Should().BeFalse();
            IsNiceString("dvszwmarrgswjxmb").Should().BeFalse();
        }

        [TestMethod]
        public void Part2_TestCases()
        {
            IsNiceStringPartTwo("qjhvhtzxzqqjkmpb").Should().BeTrue();
            IsNiceStringPartTwo("xxyxx").Should().BeTrue();

            IsNiceStringPartTwo("uurcxstgmygtbstg").Should().BeFalse();
            IsNiceStringPartTwo("ieodomkazucvgmuy").Should().BeFalse();
        }

        private bool IsNiceString(string value)
        {
            var containsThreeVowels = new Func<string, bool>(x =>
                x.ToCharArray().GroupBy(c => c)
                               .Where(c => new[] {'a', 'e', 'i', 'o', 'u'}.Contains(c.Key))
                               .SelectMany(c => c.ToList())
                               .Count() >= 3
            );

            var containsTwoConsecutiveCharacters = new Func<string, bool>(x => 
                HasTwoRepeatingCharacters.IsMatch(x));

            var containsForbiddenString = new Func<string, bool>(x =>
                new[] { "ab", "cd", "pq", "xy" }.Any(x.Contains));

             return
                containsThreeVowels(value) &&
                containsTwoConsecutiveCharacters(value) &&
                !containsForbiddenString(value);
        }

        private bool IsNiceStringPartTwo(string value)
        {
            return
                HasTwoLetterRepetition.IsMatch(value) &&
                HasRepeatingCharacterWithOneLetterInBetween.IsMatch(value);
        }
    }
}