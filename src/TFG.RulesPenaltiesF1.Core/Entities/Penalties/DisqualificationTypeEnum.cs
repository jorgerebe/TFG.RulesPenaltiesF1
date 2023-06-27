using Ardalis.SmartEnum;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;

public class DisqualificationTypeEnum : SmartEnum<DisqualificationTypeEnum>
{
	public static readonly DisqualificationTypeEnum Current = new("Current", 1);
	public static readonly DisqualificationTypeEnum Next = new("Next", 2);
	public static readonly DisqualificationTypeEnum LicensePointsLimit = new("LicensePointsLimit", 3);

	public DisqualificationTypeEnum(string name, int value) : base(name, value)
	{

	}
}
