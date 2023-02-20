﻿using System.Reflection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;

public class RulesPenaltiesF1DbContext : DbContext
{
   private readonly IDomainEventDispatcher? _dispatcher;

   public RulesPenaltiesF1DbContext(DbContextOptions<RulesPenaltiesF1DbContext> options,
     IDomainEventDispatcher? dispatcher)
       : base(options)
   {
      _dispatcher = dispatcher;
   }

   public RulesPenaltiesF1DbContext(DbContextOptions<RulesPenaltiesF1DbContext> options) : base(options) { }

   public DbSet<Article> Articles => Set<Article>();

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
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