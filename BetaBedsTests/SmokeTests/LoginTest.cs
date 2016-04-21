using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetaBedsAutomation;

namespace BetaBedsTests
{
    [TestClass]
    public class LoginTest : BaseTestClass
    {
        [TestMethod]
        public void User_Successful_Login()
        {
            Assert.IsTrue(HomePage.IsDisplayed,"Failed to Login.");
        }
    }
}
