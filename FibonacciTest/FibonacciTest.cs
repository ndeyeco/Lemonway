using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ndeyeServices;


namespace FibonacciTest
{
    [TestClass]
    public class FibonacciTest
    {
        Fibonacci service = new Fibonacci();
        [TestMethod]
        
        public void Should_fibonacci_Itterative_1_return_1()
        {
           
            Assert.AreEqual(1, service.FibonacciItterative(1));
        }

        [TestMethod]
        
        public void Should_fibonacci_Itterative_6_return_8()
        {
            Assert.AreEqual(8, service.FibonacciItterative(6), "FibonacciItterative(6) failed");
        }

        [TestMethod]
        
        public void Should_fibonacci_Itterative_101_return_minus1()
        {
            Assert.AreEqual(-1, service.FibonacciItterative(101), "FibonacciItterative(101) failed");
        }

        
         [TestMethod]
        public void Should_fibonacci_Itterative_71_return_308061521170129()
        {
            Assert.AreEqual(308061521170129, service.FibonacciItterative(71), "FibonacciItterative(71) failed");
        }
        [TestMethod]
        public void Should_fibonacci_Itterative_100_return_354224848179261915075()
        {
            Assert.AreEqual(System.Numerics.BigInteger.Parse("354224848179261915075"), service.FibonacciItterative(100), "FibonacciItterative(100) failed");
        }

        [TestMethod]
        public void Should_fibonacci_Itterative_43_return_433494437()
        {
            Assert.AreEqual(433494437, service.FibonacciItterative(43), "FibonacciItterative(43) failed");
        }
    }
}
