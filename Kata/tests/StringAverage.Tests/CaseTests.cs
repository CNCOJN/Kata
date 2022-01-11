using FluentAssertions;
using NUnit.Framework;

namespace StringAverage.Tests
{
    [TestFixture]
    public class CaseTests
    {
        private Case? _case;

        [SetUp]
        public void SetUp()
        {
            _case = new();
        }

        [TestCase(null)]
        [TestCase("")]
        public void StringAverage1_GivenNullOrEmptyString_ReutrnsNA(string input)
        {
            string message = "n/a";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }

        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("    ")]
        public void StringAverage1_GivenBlankSpaces_ReutrnsNA(string input)
        {
            string message = "n/a";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }

        [TestCase("one two three")]
        [TestCase("One tWo threE")]
        [TestCase("three two one")]
        [TestCase("Three tWo onE")]
        [TestCase("ONE TWO THREE")]
        public void StringAverage1_GivenOneTwoThree_ReturnsTwo(string input)
        {
            string message = "two";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }

        [TestCase("one  two three")]
        [TestCase("One  tWo  threE")]
        [TestCase("three  two one")]
        [TestCase("Three tWo  onE")]
        [TestCase("ONE  TWO  THREE")]
        public void StringAverage1_GivenOneTwoThreeAndAddSpacesBetweenThem_ReturnsTwo(string input)
        {
            string message = "two";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }

        [TestCase("one two twelve")]
        [TestCase("twelve two one")]
        public void StringAverage1_GivenGreaterThanNine_ReturnsNA(string input)
        {
            string message = "n/a";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }

        [TestCase("one two Not_A_Number")]
        [TestCase("one  two  Not_A_Number")]
        [TestCase("Not_A_Number two one")]
        [TestCase("Not_A_Number  two  one")]
        public void StringAverage1_GivenStringContainsNonNumber_ReturnsNA(string input)
        {
            string message = "n/a";
            
            var result = _case?.StringAverage1(input);
            
            result.Should().Be(message);
        }
    }
}