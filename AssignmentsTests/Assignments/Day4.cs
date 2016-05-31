using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using AssignmentsTests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentsTests.Assignments
{
    [TestClass]
    public class Day4
    {
        private MD5 _md5;

        [TestInitialize]
        public void Intitialize()
        {
            _md5 = MD5.Create();
        }

        [TestMethod]
        public void Solve()
        {
            Console.WriteLine(GetCorrectHash(Files.Day4, hashShouldStartWith: "00000"));
        }

        [TestMethod]
        public void Solve_Part2()
        {
            Console.WriteLine(GetCorrectHash(Files.Day4, hashShouldStartWith: "000000"));
        }

        [TestMethod]
        public void Part1_TestCase1()
        {
            GetCorrectHash("abcdef", hashShouldStartWith: "00000").Should().Be(609043);
        }

        [TestMethod]
        public void Part1_TestCase2()
        {
            GetCorrectHash("pqrstuv", hashShouldStartWith: "00000").Should().Be(1048970);
        }

        public int GetCorrectHash(string key, string hashShouldStartWith)
        {
            int iteration = 0;

            while (!GetHash(key, iteration).StartsWith(hashShouldStartWith))
            {
                iteration++;
            }

            return iteration;
        }

        private string GetHash(string key, int iteration)
        {
            var bytes = Encoding.ASCII.GetBytes(string.Format("{0}{1}", key, iteration));
            return new SoapHexBinary(_md5.ComputeHash(bytes)).ToString();
        }
    }
}
