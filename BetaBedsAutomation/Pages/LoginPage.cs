using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BetaBedsAutomation.Enums;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Log;
using BetaBedsUITestLogger;
using BetaBedsAutomation.Functions;

namespace BetaBedsAutomation
{
    public class LoginPage
    {

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("RememberMe"), 40, "Login page not displayed in 40 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    Guids.pageUrl = PageFunctions.GetUrl();
                }

            }
        }


        public static void GoTo(TestEnvironment env, string customUrl)
        {
            Logger.AddCustomMsg("Goto ", env.ToString(), " environment");

            switch (env)
            {
                case TestEnvironment.Local:
                    Driver.Instance.Navigate().GoToUrl(customUrl);
                    break;

                case TestEnvironment.Dev:
                    Driver.Instance.Navigate().GoToUrl("http://trunk.betabeds.com");
                    break;

                case TestEnvironment.QA:
                    Driver.Instance.Navigate().GoToUrl("http://qa.betabeds.com");
                    break;

                case TestEnvironment.Staging:
                    Driver.Instance.Navigate().GoToUrl("http://staging.betabeds.com");
                    break;

                case TestEnvironment.Live:
                    Driver.Instance.Navigate().GoToUrl("http://betabeds.com");
                    break;
            }
            Guids.SearchGuid = null;
            Guids.ValuationGUID = null;
            Guids.pageUrl = PageFunctions.GetUrl();
            
        }


        public static void TypeAgentUserName(string userName)
        {
            Logger.AddTypeAction(userName, "Username text box");
            var userNameTextBox = Driver.Instance.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys(userName);
        }

        public static void TypeAgentPassword(string password)
        {
            Logger.AddTypeAction(password, "Password text box");
            var passwordTextBox = Driver.Instance.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys(password);
        }

        public static void ClickLoginButton()
        {
            Logger.AddClickAction("Login button");
            var loginButton = Driver.Instance.FindElement(By.ClassName("btn"));
            loginButton.Click();
        }


        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }


    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(String userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {

            LoginPage.TypeAgentUserName(userName);

            LoginPage.TypeAgentPassword(password);

            LoginPage.ClickLoginButton();

        }
    }

}
