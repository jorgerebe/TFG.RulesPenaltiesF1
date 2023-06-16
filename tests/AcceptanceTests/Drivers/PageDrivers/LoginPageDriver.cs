using AcceptanceTests.PageObjects;

namespace AcceptanceTests.Drivers.PageDrivers;

public class LoginPageDriver
{
	private readonly HomePageObjectModel _homePageObjectModel;

	public LoginPageDriver(BrowserDriver browserDriver)
	{
		_homePageObjectModel = new HomePageObjectModel(browserDriver.Current);
	}

	public void CheckLoggedInCorrectly(string email)
	{
		_homePageObjectModel.EnsureHomePageIsOpen();
		_homePageObjectModel.GetMessageAccountElement().Should().Be($"Hello {email}!");
	}
}
