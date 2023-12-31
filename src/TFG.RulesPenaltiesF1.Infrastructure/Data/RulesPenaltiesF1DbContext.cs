﻿using System.Reflection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using SmartEnum.EFCore;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;

public class RulesPenaltiesF1DbContext : IdentityDbContext
{
   private readonly IDomainEventDispatcher? _dispatcher;

   public RulesPenaltiesF1DbContext(DbContextOptions<RulesPenaltiesF1DbContext> options,
     IDomainEventDispatcher? dispatcher)
       : base(options)
   {
      _dispatcher = dispatcher;
   }

   public RulesPenaltiesF1DbContext(DbContextOptions<RulesPenaltiesF1DbContext> options) : base(options) { }

   public DbSet<Article> Article => Set<Article>();
   public DbSet<PenaltyType> PenaltyType => Set<PenaltyType>();
   public DbSet<Penalty> Penalty => Set<Penalty>();
   public DbSet<Disqualification> Disqualification => Set<Disqualification>();

   public DbSet<RegulationArticle> RegulationArticle => Set<RegulationArticle>();
   public DbSet<RegulationPenalty> RegulationPenalty => Set<RegulationPenalty>();
   public DbSet<Regulation> Regulation => Set<Regulation>();
   public DbSet<Country> Country => Set<Country>();
   public DbSet<Circuit> Circuit => Set<Circuit>();
   public DbSet<Competitor> Competitor => Set<Competitor>();
   public DbSet<ApplicationUser> User => Set<ApplicationUser>();

	public DbSet<Driver> Driver => Set<Driver>();

	public DbSet<Season> Season => Set<Season>();
   public DbSet<Session> Session => Set<Session>();
   public DbSet<Competition> Competition => Set<Competition>();
   public DbSet<Participation> Participation => Set<Participation>();
   public DbSet<Incident> Incident => Set<Incident>();

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

		modelBuilder.ConfigureSmartEnum();
      modelBuilder.Ignore<User>();

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
   }

   public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
   {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

      // ignore events if no dispatcher provided
      if (_dispatcher == null) return result;

      // dispatch events only if save was successful
      var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
          .Select(e => e.Entity)
          .Where(e => e.DomainEvents.Any())
          .ToArray();

      await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

      return result;
   }

   public override int SaveChanges()
   {
      return SaveChangesAsync().GetAwaiter().GetResult();
   }
}
