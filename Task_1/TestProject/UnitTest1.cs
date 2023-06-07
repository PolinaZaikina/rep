namespace Task_1
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void ConstructorValidValuesSuccess()
        {
            int a = 5;
            int b = 10;

            Range range = new Range(a, b);

            Assert.AreEqual(a, range.A);
            Assert.AreEqual(b, range.B);
            Assert.AreEqual(b - a, range.Count);
        }

        [Test]
        public void ConstructorInvalidValuesThrowsArgumentException()
        {
            int a = 10;
            int b = 5;

            Assert.Throws<ArgumentException>(() => new Range(a, b));
        }

        [Test]
        public void IsContainsNumberInBoundsTrue()
        {
            Range range = new Range(5, 10);
            int number = 7;

            bool result = range.IsContains(number);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsContainsNumberNotInBoundsFalse()
        {
            Range range = new Range(5, 10);
            int number = 12;

            bool result = range.IsContains(number);
            Assert.IsFalse(result);
        }

        [Test]
        public void ToStringFormattedString()
        {
            Range range = new Range(5, 10);
            string expected = "[5; 10)";

            string result = range.ToString();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EqualRangesTrue()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(5, 10);

            bool result = range1.Equals(range2);

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsUnequalRangesFalse()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(10, 15);

            bool result = range1.Equals(range2);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetHashCodeEqualRangesSameHashCode()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(5, 10);

            int hashCode1 = range1.GetHashCode();
            int hashCode2 = range2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        public void OperatorAndIntersectedRange()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(8, 12);
            Range expected = new Range(8, 10);

            Range result = range1 & range2;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OperatorAndDisjointRangesEmptyRange()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(11, 15);
            Range expected = new Range(0, 0);

            Range result = range1 & range2;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OperatorOrSmallestRangeContainingBoth()
        {
            Range range1 = new Range(5, 10);
            Range range2 = new Range(8, 15);
            Range expected = new Range(5, 15);

            Range result = range1 | range2;

            Assert.AreEqual(expected, result);
        }
    }
}