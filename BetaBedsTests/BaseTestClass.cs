using System;
using BetaBedsAutomation;
using BetaBedsTests.Properties;
using NUnit.Framework;
using BetaBedsAutomation.Enums;
using BetaBedsAutomation.Data;
using BetaBedsUITestLogger;






namespace BetaBedsTests
{
    [TestFixture]
    public class BaseTestClass
    {

        [SetUp]
        public void Initialise()
        {
            Logger.AddCustomMsg("Test Name: ", TestContext.CurrentContext.Test.FullName);
            Logger.AddCustomMsg("Steps to replicate:");

            Driver.Initialise(Settings.Default.TestingEnvironment, Settings.Default.SeleniumExecuteLocally, Settings.Default.SeleniumBrowser, Settings.Default.SeleniumRemoteServerURL, Settings.Default.ProxyEnabled, Settings.Default.HttpProxy, Settings.Default.HttpPort);

            LoginPage.GoTo((TestEnvironment)Enum.Parse(typeof(TestEnvironment), Settings.Default.TestingEnvironment),Settings.Default.CustomURL);

        }


        [TearDown]
        public void Cleanup()
        {
            Driver.Close();
            System.Console.WriteLine("Search id: " + Guids.SearchGuid + "\nPageUrl: " + Guids.pageUrl);
        }
    }
}
