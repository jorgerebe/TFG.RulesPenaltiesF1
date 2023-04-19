﻿using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface IDriverRepository : IRepository<Driver>
{
	Task<List<Driver>> GetAllDrivers();
	Task<Driver?> GetDriverById(int id);
}