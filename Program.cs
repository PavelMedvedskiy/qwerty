using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Test
{
    class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        
    }
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://gmail.com");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void ExecuteTest()
        {
            User user1 = new User();
            user1.Login = "autotest4322@gmail.com";
            user1.Password = "qwerty655";

            IWebElement LoginField = driver.FindElement(By.Id("identifierId"));
            LoginField.SendKeys(user1.Login);

            IWebElement NetxButtonLogin = driver.FindElement(By.XPath(".//*[@id='identifierNext']/content/span"));
            NetxButtonLogin.Click();

            System.Threading.Thread.Sleep(2000);


            IWebElement PasswordField = driver.FindElement(By.Name("password"));
            PasswordField.SendKeys(user1.Password);

            IWebElement NextButtonPassword = driver.FindElement(By.XPath(".//*[@id='passwordNext']/content/span"));
            NextButtonPassword.Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement Icon = driver.FindElement(By.XPath(".//*[@id='gb']/div[1]/div[1]/div[2]/div[5]/div[1]/a/span"));
        }
        [Test]


        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
        static void Main(string[] args)
        {
        }
    }
}
