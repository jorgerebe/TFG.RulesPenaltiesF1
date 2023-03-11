using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class PenaltyViewModelFactory
{
   public static PenaltyViewModel CreateViewModel(Penalty penalty)
   {

      var viewModel = new PenaltyViewModel();


      switch(penalty)
      {
         case Fine fine:
            viewModel = CreateViewModel(fine);
            break;
         case Disqualification disqualification:
            viewModel = CreateViewModel(disqualification);
            break;
         case StopAndGo stopAndGo:
            viewModel = CreateViewModel(stopAndGo);
            break;
         case DriveThrough driveThrough:
            viewModel = CreateViewModel(driveThrough);
            break;
         case TimePenalty timePenalty:
            viewModel = CreateViewModel(timePenalty);
            break;
         case Reprimand reprimand:
            viewModel = CreateViewModel(reprimand);
            break;
         case DropGridPositions dropGridPositions:
            viewModel = CreateViewModel(dropGridPositions);
            break;
      }

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(Reprimand reprimand)
   {
      var viewModel = new ReprimandViewModel
      {
         IsDriving = reprimand.DrivingReprimand
      };

      SetCommonProperties(viewModel, reprimand);

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(Disqualification disqualification)
   {
      var viewModel = new DisqualificationViewModel
      {
         NextCompetition = disqualification.NextCompetition
      };

      SetCommonProperties(viewModel, disqualification);

      return viewModel;
   }
   
   public static PenaltyViewModel CreateViewModel(DriveThrough driveThrough)
   {
      var viewModel = new DriveThroughViewModel
      {
         ElapsedTime = driveThrough.ElapsedSeconds
      };

      SetCommonProperties(viewModel, driveThrough);

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(DropGridPositions dropGridPositions)
   {
      var viewModel = new DropGridPositionsViewModel
      {
         Positions = dropGridPositions.Positions
      };

      SetCommonProperties(viewModel, dropGridPositions);

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(Fine fine)
   {
      var viewModel = new PenaltyViewModel();

      SetCommonProperties(viewModel, fine);

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(StopAndGo stopAndGo)
   {
      var viewModel = new StopAndGoViewModel
      {
         ElapsedTime = stopAndGo.ElapsedSeconds,
         Seconds = stopAndGo.Seconds
      };

      SetCommonProperties(viewModel, stopAndGo);

      return viewModel;
   }

   public static PenaltyViewModel CreateViewModel(TimePenalty timePenalty)
   {
      var viewModel = new TimePenaltyViewModel
      {
         Seconds = timePenalty.Seconds
      };

      SetCommonProperties(viewModel, timePenalty);

      return viewModel;
   }

   private static void SetCommonProperties(PenaltyViewModel viewModel, Penalty penalty)
   {
      viewModel.Id = penalty.Id;
      viewModel.Name = penalty.PenaltyType.Name;
      viewModel.Description = penalty.PenaltyType.Description;
   }
}
