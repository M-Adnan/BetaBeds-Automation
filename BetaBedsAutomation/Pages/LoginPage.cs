using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BetaBedsAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
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
