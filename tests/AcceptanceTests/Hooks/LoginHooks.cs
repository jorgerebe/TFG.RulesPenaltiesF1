using AcceptanceTests.Drivers;
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.Hooks;

[Binding]
internal class LoginHooks
{
	[Scope(Tag ="stewardlogin")]
	[BeforeScenario(Order = 40)]
	public void LoginSteward(BrowserDriver browserDriver)
	{
		LoginPageObjectModel loginPageObjectModel = new LoginPageObjectModel(browserDriver.Current);
		loginPageObjectModel.EnsureLoginPageIsOpenAndReset();
		loginPageObjectModel.EnterEmail("steward@steward.com");
		loginPageObjectModel.EnterPassword("Steward.");
		loginPageObjectModel.Submit();
	}
}
