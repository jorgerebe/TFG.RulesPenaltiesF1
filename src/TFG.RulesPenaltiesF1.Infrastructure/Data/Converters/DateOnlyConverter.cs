﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Converters;
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
	public DateOnlyConverter() : base(d => d.ToDateTime(TimeOnly.MinValue), d => DateOnly.FromDateTime(d))
	{ }
}
