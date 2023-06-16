using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.PageObjects;
public class LoginPageObjectModel
{
	private const string LoginUrl = "https://localhost:33333/Identity/Account/Login";

	private readonly IWebDriver _webDriver;

	public const int DefaultWaitInSeconds = 5;

	public LoginPageObjectModel(IWebDriver webDriver)
	{
		_webDriver = webDriver;
	}

	private IWebElement EmailInput => _webDriver.FindElement(By.Id("Input_Email"));
	private IWebElement PasswordInput => _webDriver.FindElement(By.Id("Input_Password"));
	private IWebElement SubmitButton => _webDriver.FindElement(By.Id("login-submit"));

	public void EnterEmail(string email)
	{
		EmailInput.SendKeys(email);
	}

	public void EnterPassword(string password)
	{
		PasswordInput.SendKeys(password);
	}

	public void Submit()
	{
		SubmitButton.Click();
	}

	public void EnsureLoginPageIsOpenAndReset()
	{
		if (_webDriver.Url != LoginUrl)
		{
			_webDriver.Url = LoginUrl;
		}
		else
		{
			EmailInput.Clear();
			PasswordInput.Clear();
		}
	}
}
