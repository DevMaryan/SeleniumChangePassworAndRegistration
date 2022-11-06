using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFive
{
    [TestFixture]

    public class SeleniumNine : Setup
    {
        [Test]
        public void ChangePassword()
        {
            // SIGN IN

            // Open form
            IWebElement showLoginForm = _webDriver.FindElement(By.Id("login"));
            showLoginForm.Click();

            // Wait to open the form
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Target username and enter data
            IWebElement usernameField = _webDriver.FindElement(By.Id("username"));
            usernameField.Clear();
            usernameField.SendKeys("maryan.shapkaroski2@gmail.com");

            // Target password and enter data
            IWebElement passwordField = _webDriver.FindElement(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys("Rw@w!5!e");

            // Wait until the button is visible
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='btn btn-green']")));

            // Click on Sign in button
            _webDriver.FindElement(By.CssSelector("button[class='btn btn-green']")).Click();

            // Wait Dashboard to be loaded
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='/client/home']")));

            // Click on my account
            _webDriver.FindElement(By.CssSelector("a[href*='/client/account']")).Click();

            // Wait My profile to be loaded
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[type='submit']")));

            // Click on change my password
            _webDriver.FindElement(By.CssSelector("a[href*='/client/password']")).Click();

            // Wait Change my password page to be loaded
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password")));

            // Enter new passwords

            // Target password and enter data
            IWebElement newPassword = _webDriver.FindElement(By.Id("password"));
            newPassword.Clear();
            newPassword.SendKeys("Rw@w!5!e");
 

            IWebElement confirmPassword = _webDriver.FindElement(By.Id("confirmPassword"));
            confirmPassword.Clear();
            confirmPassword.SendKeys("Rw@w!5!e");


            // VALIDATION

            IWebElement strBar = _webDriver.FindElement(By.Id("strengthBar"));
            List<IWebElement> strPoints = strBar.FindElements(By.CssSelector("li[class='point']")).ToList();

            int counter = 0;

            for (var i = 0; i < strPoints.Count; i++)
            {
                if (strPoints[i].GetCssValue("background-color").Contains("0, 255, 0"))
                {
                    counter++;
                }
            }

            Assert.AreEqual(5, counter);



            // Click on Save - password updated
            _webDriver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Logout
            _webDriver.FindElement(By.Id("logout2")).Click();

            // Open form
            IWebElement showLoginFormAgain = _webDriver.FindElement(By.Id("login"));
            showLoginFormAgain.Click();

            // Wait to open the form
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Target username and enter data
            IWebElement usernameFieldAgain = _webDriver.FindElement(By.Id("username"));
            usernameFieldAgain.Clear();
            usernameFieldAgain.SendKeys("maryan.shapkaroski2@gmail.com");

            // Target password and enter data
            IWebElement passwordFieldNew = _webDriver.FindElement(By.Id("password"));
            passwordFieldNew.Clear();
            passwordFieldNew.SendKeys("Rw@w!5!e");

            // Click on Sign in button
            _webDriver.FindElement(By.CssSelector("button[class='btn btn-green']")).Click();
        }

        //[Test]
        //public void RegistrationPending()
        //{
        //    // Click on Register Button
        //    _webDriver.FindElement(By.CssSelector("a[href*='/account-type']")).Click();

        //    // Select 'I am transporter'
        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='btn btn-green account-type__button']")));
        //    _webDriver.FindElement(By.CssSelector("button[class='btn btn-green account-type__button']")).Click();

        //    // FORM
        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[class='btn btn-green center-block'")));

        //    // First name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerFirstName']")).SendKeys("Marjan");

        //    // Last name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerLastName']")).SendKeys("Shapkaroski");

        //    // Company name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyName']")).SendKeys("ODWE");

        //    // Address
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyAddress']")).SendKeys("7171 W Gunnison St");

        //    // City
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyCity']")).SendKeys("Chicago");

        //    // Postal Code
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyPostalCode']")).SendKeys("60706");

        //    // Country
        //     _webDriver.FindElement(By.CssSelector("span[class='btn btn-default form-control ui-select-toggle']")).Click();
        //    _webDriver.FindElement(By.CssSelector("span[country='US']")).Click();

        //    // Tax number
        //    _webDriver.FindElement(By.CssSelector("input[name='companyTaxNumber']")).SendKeys("89714760706");

        //    // Phone number
        //    _webDriver.FindElement(By.CssSelector("input[name='phoneNumber']")).SendKeys("0792786181");

        //    // Email

        //    _webDriver.FindElement(By.CssSelector("input[name='email']")).SendKeys($"maryan.shapkaroski{new Random().Next()}@gmail.com");

        //    // Password
        //    int pwd = new Random().Next();
        //    _webDriver.FindElement(By.CssSelector("input[name='password']")).SendKeys(pwd.ToString());

        //    // Confirm Password
        //    _webDriver.FindElement(By.CssSelector("input[name='confirmPassword']")).SendKeys(pwd.ToString());

        //    // Terms and policy
        //    _webDriver.FindElement(By.CssSelector("input[name='acceptTerms']")).Click();

        //    // Match if registration is NOT completed
        //    Assert.Multiple(() =>
        //    {
        //        Assert.AreNotEqual(registrationCompleted, _webDriver.Url, $"Registration is NOT successful!");
        //    });

        //}

        //[Test]
        //public void TableExercise()
        //{
        //    // CLASS
        //    IWebElement tableBody = _webDriver.FindElement(By.ClassName("table-body"));
        //    List<IWebElement> listOfRows = tableBody.FindElements(By.CssSelector("tr[ng-repeat=request in vm.requests | filter:cargo'")).ToList();

        //    IWebElement firstRow = listOfRows.FirstOrDefault();

        //    IWebElement fourthRow = listOfRows[3];

        //    string text = fourthRow.Text;

        //    IWebElement fourthColumn = fourthRow.FindElement(By.CssSelector(".table-body__cel.column5"));

        //    string text2 = fourthColumn.Text;

        //}

        //[Test]
        //public void RegistrationSuccessful()
        //{
        //    // Click on Register Button
        //    _webDriver.FindElement(By.CssSelector("a[href*='/account-type']")).Click();

        //    // Select 'I am transporter'
        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='btn btn-green account-type__button']")));
        //    _webDriver.FindElement(By.CssSelector("button[class='btn btn-green account-type__button']")).Click();

        //    // FORM
        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[class='btn btn-green center-block'")));

        //    // First name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerFirstName']")).SendKeys("Marjan");

        //    // Last name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerLastName']")).SendKeys("Shapkaroski");

        //    // Company name
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyName']")).SendKeys("ODWE");

        //    // Address
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyAddress']")).SendKeys("7171 W Gunnison St");

        //    // City
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyCity']")).SendKeys("Chicago");

        //    // Postal Code
        //    _webDriver.FindElement(By.CssSelector("input[name='providerCompanyPostalCode']")).SendKeys("60706");

        //    // Country
        //    _webDriver.FindElement(By.CssSelector("span[class='btn btn-default form-control ui-select-toggle']")).Click();
        //    _webDriver.FindElement(By.CssSelector("span[country='US']")).Click();

        //    // Tax number
        //    _webDriver.FindElement(By.CssSelector("input[name='companyTaxNumber']")).SendKeys("89714760706");

        //    // Phone number
        //    _webDriver.FindElement(By.CssSelector("input[name='phoneNumber']")).SendKeys("0792786181");

        //    // Email

        //    _webDriver.FindElement(By.CssSelector("input[name='email']")).SendKeys($"maryan.shapkaroski{new Random().Next()}@gmail.com");

        //    // Password
        //    int pwd = new Random().Next();
        //    _webDriver.FindElement(By.CssSelector("input[name='password']")).SendKeys(pwd.ToString());

        //    // Confirm Password
        //    _webDriver.FindElement(By.CssSelector("input[name='confirmPassword']")).SendKeys(pwd.ToString());

        //    // Terms and policy
        //    _webDriver.FindElement(By.CssSelector("input[name='acceptTerms']")).Click();

        //    // Button Register
        //    _webDriver.FindElement(By.CssSelector("input[type='submit']")).Click();

        //    // Match if registration is completed
        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("h1[class='successful-registration__main-title']")));

        //    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(registrationCompleted));

        //    Assert.Multiple(() =>
        //    {
        //        Assert.IsNotNull(_webDriver.Url);
        //        Assert.AreEqual(registrationCompleted, _webDriver.Url, $"Registration is successful!");
        //    });

        //}

    }
}
