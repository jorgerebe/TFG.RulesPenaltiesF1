using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class PenaltyViewModelFactory
{
   public static PenaltyViewModel CreateViewModel(Penalty penalty)
   {

      var viewModel = penalty switch
      {
         Fine fine => CreateViewModel(fine),
         Disqualification disqualification => CreateViewModel(disqualification),
         StopAndGo stopAndGo => CreateViewModel(stopAndGo),
         DriveThrough driveThrough => CreateViewModel(driveThrough),
         TimePenalty timePenalty => CreateViewModel(timePenalty),
         Reprimand reprimand => CreateViewModel(reprimand),
         DropGridPositions dropGridPositions => CreateViewModel(dropGridPositions),
         _ => throw new ArgumentException("Invalid penalty"),
      };
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
			Type = disqualification.Type
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

		viewModel.Name = timePenalty.PenaltyType.Name + " - " + timePenalty.Seconds + " seconds";

      return viewModel;
   }

   private static void SetCommonProperties(PenaltyViewModel viewModel, Penalty penalty)
   {
      viewModel.Id = penalty.Id;
      viewModel.Name = penalty.PenaltyType.Name;
      viewModel.Description = penalty.PenaltyType.Description;
		viewModel.PenaltyPoints = penalty.PenaltyType.PenaltyPoints;
		viewModel.Fine = penalty.PenaltyType.Fine;
   }
}
