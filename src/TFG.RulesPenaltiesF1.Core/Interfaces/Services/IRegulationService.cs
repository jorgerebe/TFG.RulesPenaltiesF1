﻿using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;
public interface IRegulationService
{
   Task CreateRegulationAsync(Regulation article);
}
