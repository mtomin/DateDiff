using DateDiff;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // a segment overlaps
        [TestMethod]
        public void TestMethod1()
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from,
                To = from.Add(new TimeSpan(2, 3, 10))
            };
            var dr2 = new DateRange
            {
                From = from.Add(new TimeSpan(-1, 0, 0)),
                To = from.Add(new TimeSpan(1, 3, 0))
            };
            var drDiff = CalculationHelper.Calculate(dr1, dr2);

            Assert.AreEqual(drDiff.From, from);
            Assert.AreEqual(drDiff.To, from.Add(new TimeSpan(1, 3, 0)));
        }

        // from values overlap
        [TestMethod]
        public void TestMethod2()
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from,
                To = from.Add(new TimeSpan(2, 3, 10))
            };
            var dr2 = new DateRange
            {
                From = from,
                To = from.Add(new TimeSpan(1, 3, 0))
            };
            var drDiff = CalculationHelper.Calculate(dr1, dr2);

            Assert.AreEqual(drDiff.From, from);
            Assert.AreEqual(drDiff.To, from.Add(new TimeSpan(1, 3, 0)));
        }

        // dr2 is contained within dr1
        [TestMethod]
        public void TestMethod3()
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from,
                To = from.Add(new TimeSpan(2, 3, 10))
            };
            var dr2 = new DateRange
            {
                From = from.AddHours(1),
                To = from.Add(new TimeSpan(1, 3, 0))
            };
            var drDiff = CalculationHelper.Calculate(dr1, dr2);

            Assert.AreEqual(drDiff.From, from.AddHours(1));
            Assert.AreEqual(drDiff.To, from.Add(new TimeSpan(1, 3, 0)));
        }

        // dr2 is a single point
        [TestMethod]
        public void TestMethod4()
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from,
                To = from.Add(new TimeSpan(2, 3, 10))
            };
            var dr2 = new DateRange
            {
                From = from.AddHours(1),
                To = from.AddHours(1)
            };
            var drDiff = CalculationHelper.Calculate(dr1, dr2);

            Assert.AreEqual(drDiff.From, from.AddHours(1));
            Assert.AreEqual(drDiff.To, from.AddHours(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Datumi se ne preklapaju!")]
        public void TestMethod5()
        {
            var from = DateTime.Now;
            var dr1 = new DateRange
            {
                From = from,
                To = from.AddMinutes(10)
            };
            var dr2 = new DateRange
            {
                From = from.AddHours(1),
                To = from.AddHours(2)
            };
            var drDiff = CalculationHelper.Calculate(dr1, dr2);
        }
    }
}
