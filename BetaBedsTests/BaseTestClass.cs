using System;
using BetaBedsAutomation;
using BetaBedsTests.Properties;
using NUnit.Framework;
using BetaBedsAutomation.Enums;
using BetaBedsAutomation.Data;



namespace BetaBedsTests
{
    [TestFixture]
    public class BaseTestClass
    {
        [SetUp]
        public void Initialise()
        {
            Driver.Initialise(Settings.Default.TestingEnvironment, Settings.Default.SeleniumExecuteLocally, Settings.Default.SeleniumBrowser, Settings.Default.SeleniumRemoteServerURL, Settings.Default.ProxyEnabled, Settings.Default.HttpProxy, Settings.Default.HttpPort);

            LoginPage.GoTo((TestEnvironment)Enum.Parse(typeof(TestEnvironment), Settings.Default.TestingEnvironment),Settings.Default.CustomURL);

        }


        [TearDown]
        public void Cleanup()
        {
            Driver.Close();
            //System.Console.WriteLine("Search id: " + Guids.SearchGuid);
            //Guids.SearchGuid = null;
        }
    }
}
