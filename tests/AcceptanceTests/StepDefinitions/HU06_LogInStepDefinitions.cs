using AcceptanceTests.Drivers.PageDrivers;
using AcceptanceTests.Drivers;
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.StepDefinitions;

[Binding]
public class HU06_LogInStepDefinitions
{
	private readonly LoginPageObjectModel _loginPageObjectModel;
	private readonly LoginPageDriver _loginPageDriver;

	public HU06_LogInStepDefinitions(BrowserDriver browserDriver)
	{
		_loginPageObjectModel = new LoginPageObjectModel(browserDriver.Current);
		_loginPageDriver = new LoginPageDriver(browserDriver);
	}

	[Given(@"\[The user is in the log in page]")]
   public void GivenTheUserIsInTheLogInPage()
   {
		_loginPageObjectModel.EnsureLoginPageIsOpenAndReset();
   }

   [When(@"\[The user enters its email]")]
   public void WhenTheUserEntersItsEmail()
   {
		_loginPageObjectModel.EnterEmail("steward@steward.com");
   }

   [When(@"\[The user enters its password]")]
   public void WhenTheUserEntersItsPassword()
   {
		_loginPageObjectModel.EnterPassword("Steward.");
	}

   [When(@"\[The user submits the login form]")]
   public void WhenTheUserSubmitsTheLoginForm()
   {
		_loginPageObjectModel.Submit();
   }

   [Then(@"\[The user is logged in in the system]")]
   public void ThenTheUserIsLoggedInInTheSystem()
   {
		_loginPageDriver.CheckLoggedInCorrectly("steward@steward.com");
   }
}
