using System;
using BetaBedsAutomation;
using BetaBedsTests.Properties;
using NUnit.Framework;
using BetaBedsAutomation.Enums;

namespace BetaBedsTests
{
    [TestFixture]
    public class BaseTestClass
    {
        [SetUp]
        public void Initialise()
        {
            Driver.Initialise(Settings.Default.TestingEnvironment, Settings.Default.SeleniumExecuteLocally, Settings.Default.SeleniumBrowser, Settings.Default.SeleniumRemoteServerURL, Settings.Default.HttpProxy, Settings.Default.HttpPort);

            LoginPage.GoTo((TestEnvironment)Enum.Parse(typeof(TestEnvironment), Settings.Default.TestingEnvironment));

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");
        }


        [TearDown]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
