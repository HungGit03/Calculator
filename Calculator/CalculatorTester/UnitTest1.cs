using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using System.Data;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        Calculation c;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void SetUp()
        {
            c = new Calculation(10, 5);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            int expected = 15, actual;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSubOperator()
        {
            int expected = 5, actual;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMulOperator()
        {
            int expected = 50, actual;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDivOperator()
        {
            int expected = 2, actual;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            c = new Calculation(10, 0);
            c.Execute("/");
        }
        //Liên kết data vs project
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                @".Data\TestData.csv", "TestData#csv",DataAccessMethod.Sequential)]
        public void TestWithDataSource()
        {
            int a,b, expected, actual;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            expected = int.Parse(TestContext.DataRow[2].ToString());
            c = new Calculation(a, b);
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
    }
}
