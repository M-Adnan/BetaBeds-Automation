using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaBedsAutomation;

namespace BetaBedsTests
{
    [TestClass]
    public class BaseTestClass
    {
        [TestInitialize]
        public void Initialise()
        {
            Driver.Initialise();

            LoginPage.GoTo();

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Driver.Close();
        }
    }
}
