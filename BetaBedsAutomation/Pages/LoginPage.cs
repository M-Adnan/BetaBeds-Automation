using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BetaBedsAutomation.Enums;

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
                    return Driver.FindElementWithTimeout(By.Id("RememberMe"), 60, "Login page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }


        public static void GoTo(TestEnvironment env)
        {
            switch (env)
            {
                case TestEnvironment.Local:
                    Driver.Instance.Navigate().GoToUrl("http://trunk.betabeds.com");
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
            var userNameTextBox = Driver.Instance.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys(userName);

            var passwordTextBox = Driver.Instance.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.ClassName("btn"));
            loginButton.Click();
        }
    }

}
