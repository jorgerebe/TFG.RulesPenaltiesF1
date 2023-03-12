using AcceptanceTests.Drivers;
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.StepDefinitions
{
   [Binding]
   public class HU03_RegulationsStepDefinitions
   {
      private readonly RegulationPageObjectModel _regulationPageObjectModel;
      private readonly RegulationPageDriver _regulationPageDriver;

      public HU03_RegulationsStepDefinitions(RegulationPageObjectModel regulationPageObjectModel, RegulationPageDriver regulationPageDriver)
      {
         _regulationPageObjectModel = regulationPageObjectModel;
         _regulationPageDriver = regulationPageDriver;
      }

      [Given(@"\[The steward is creating a regulation]")]
      public void GivenTheStewardIsCreatingARegulation()
      {
         _regulationPageObjectModel.EnsureArticlePageIsOpenAndReset();
      }

      [When(@"\[The steward enters the name of the regulation]")]
      public void WhenTheStewardEntersTheNameOfTheRegulation()
      {
         _regulationPageObjectModel.EnterNameRegulation("testing regulation 1");
      }


      [When(@"\[The steward selects the article part of the regulation]")]
      public void WhenTheStewardSelectsTheArticlePartOfTheRegulation()
      {
         _regulationPageObjectModel.SelectArticle(1);
      }

      [When(@"\[The steward selects two penalties for the regulation]")]
      public void WhenTheStewardSelectsTwoPenaltiesForTheRegulation()
      {
         _regulationPageObjectModel.SelectPenalty(2);
         _regulationPageObjectModel.SelectPenalty(4);
      }

      [When(@"\[The steward submits the regulation]")]
      public void WhenTheStewardSubmitsTheRegulation()
      {
         _regulationPageObjectModel.ClickSubmitRegulation();
      }

      [Then(@"\[The regulation is created]")]
      public void ThenTheRegulationIsCreated()
      {
         _regulationPageDriver.existsRegulationWithName("testing regulation 1").Should().BeTrue();
      }
   }
}
