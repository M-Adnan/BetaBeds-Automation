using System;
using NUnit.Framework;
using BetaBedsAutomation;

namespace BetaBedsTests
{
    [TestFixture]
    public class LoginTest : BaseTestClass
    {
        [Test]
        public void User_Successful_Login()
        {
            Assert.IsTrue(HomePage.IsDisplayed,"Failed to Login.");
        }
    }
}
