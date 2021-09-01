using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;

namespace Unittesting
{
    [TestFixture]
    public class UnitTest
    {
        //int a, b;
        Calculator m;
        Mock<ICalculator> mc;
        [SetUp]

        public void Initmethod()
        {
            m = new Calculator();
            mc = new Mock<ICalculator>();
        }
      
        [Test]
        public void Add()
        {
            
            Assert.AreEqual(10, m.add(5, 5));
        }

        [Test]
        public void Calculateamt()
        {
           
            Assert.AreEqual(25, m.CalculateAmt(5, 5));
        }

        [Test]
        public void CheckamtTrue()
        {
            mc.Setup(p => p.CalculateAmt(8, 7)).Returns(56);
            bool t = m.checkamt(8, 7);
            Assert.AreEqual(true, t);
        }

        [Test]
        public void CheckamtFalse()
        {
            mc.Setup(p => p.CalculateAmt(2, 2)).Returns(56);
            bool t = m.checkamt(2, 2);
            Assert.AreEqual(false, t);
        }

        [Test]
        public void CheckTempTestPass()
        {
            int k = m.CheckTemp(true);
            Assert.AreEqual(42, k);
        }

        [Test]
        public void CheckTempTestFail()
        {
            Assert.Throws<InvalidOperationException>(() => m.CheckTemp(false));
        }

        [Test]
        public void CheckAgeTestPass() 
        {
            bool result = m.checkAge(41);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void CheckAgeTestFail()
        {
            bool result = m.checkAge(41);
            Assert.AreEqual(true, result);
        }

        [Test]

        public void Messagetest()
        {
            string result = m.message("Jaya");
            string msg = "Hello Jaya";
            Assert.AreEqual(msg, result);
        }

        [TestCase("user_11", "secret@user11")]
        [TestCase("user_22", "secret@user22")]

        public void LogintestPass(string uname, string pwd)
        {
            string result = m.Login(uname, pwd);
            string j = "Welcome " + uname;
            Assert.That(j, Is.EqualTo(result));
        }

        [TestCase("user_1", "secret@user11")]
        [TestCase("user_2", "secret@user22")]

        public void LogintestFail(string uname, string pwd)
        {
            string result = m.Login(uname, pwd);
            string j = "Invalid User Id/Password";
            Assert.That(j, Is.EqualTo(result));
        }


    }
}
