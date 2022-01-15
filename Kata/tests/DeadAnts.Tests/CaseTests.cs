using FluentAssertions;
using NUnit.Framework;

namespace DeadAnts.Tests
{
    public class CaseTests
    {
        private Case _case;
        
        [SetUp]
        public void Setup()
        {
            _case = new();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase("........")]
        [TestCase(" ..  .. .. ")]
        public void GetDeadAntCount_GivenNoAntsOrNullOrEmpty_Return0DeadAnt(string ants)
        {
            var expected = 0;
            
            var actual = _case.GetDeadAntCount(ants);

            actual.Should().Be(expected);
        }

        [TestCase("ant..ant..a..ant")]
        [TestCase("ant..ant..n..ant")]
        [TestCase("ant..ant..t..ant")]
        [TestCase("Ant..ant..a..ant")]
        [TestCase("ant..aNt..n..ant")]
        [TestCase("ant..ant..t..anT")]
        public void GetDeadAntCount_GivenOneDeadAnt_Return1DeadAnt(string ants)
        {
            var expected = 1;

            var actual = _case.GetDeadAntCount(ants);

            actual.Should().Be(expected);
        }

        [TestCase("ant..ant..a..ant..n..ant.a")]
        [TestCase("ant..ant..A..ant..n..ant.a")]
        [TestCase("ant..ant..a..ant..N..ant.a")]
        [TestCase("ant..ant..a..ant..n..ant.n")]
        [TestCase("ant..ant..a..ant..n..ant.t..a")]
        [TestCase("ant..ant..a..ant..n..ant.t..n")]
        [TestCase("  Ant. .aNT. .A. .ANt. .N..aNt .t. .n")]
        public void GetDeadAntCount_GivenTwoDeadAnts_Return2DeadAnts(string ants)
        {
            var expected = 2;

            var actual = _case.GetDeadAntCount(ants);

            actual.Should().Be(expected);
        }
    }
}