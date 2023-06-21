using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.PageObjects;

public class HomePageObjectModel
{
	private const string HomeUrl = "https://localhost:33333/";

	private readonly IWebDriver _webDriver;

	public HomePageObjectModel(IWebDriver webDriver)
	{
		_webDriver = webDriver;
	}

	private IWebElement ManageLink => _webDriver.FindElement(By.Id("manage"));

	public string GetMessageAccountElement()
	{
		return ManageLink.Text;
	}

	public void EnsureHomePageIsOpen()
	{
		if (_webDriver.Url != HomeUrl)
		{
			_webDriver.Url = HomeUrl;
		}
	}
}
