﻿using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Infrastructure;

public class DefaultInfrastructureModule : Module
{
   private readonly bool _isDevelopment = false;
   private readonly List<Assembly> _assemblies = new List<Assembly>();

   public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
   {
      _isDevelopment = isDevelopment;
      var coreAssembly =
        Assembly.GetAssembly(typeof(Object)); // TODO: Replace "Object" with any type from your Core project
      var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
      if (coreAssembly != null)
      {
         _assemblies.Add(coreAssembly);
      }

      if (infrastructureAssembly != null)
      {
         _assemblies.Add(infrastructureAssembly);
      }

      if (callingAssembly != null)
      {
         _assemblies.Add(callingAssembly);
      }
   }

   protected override void Load(ContainerBuilder builder)
   {
      if (_isDevelopment)
      {
         RegisterDevelopmentOnlyDependencies(builder);
      }
      else
      {
         RegisterProductionOnlyDependencies(builder);
      }

      RegisterCommonDependencies(builder);
   }

   private void RegisterCommonDependencies(ContainerBuilder builder)
   {
      builder.RegisterGeneric(typeof(EfRepository<>))
        .As(typeof(IRepository<>))
        .InstancePerLifetimeScope();

      builder
        .RegisterType<Mediator>()
        .As<IMediator>()
        .InstancePerLifetimeScope();

      builder
        .RegisterType<DomainEventDispatcher>()
        .As<IDomainEventDispatcher>()
        .InstancePerLifetimeScope();

      builder.Register<ServiceFactory>(context =>
      {
         var c = context.Resolve<IComponentContext>();

         return t => c.Resolve(t);
      });

      var mediatrOpenTypes = new[]
      {
   typeof(IRequestHandler<,>),
   typeof(IRequestExceptionHandler<,,>),
   typeof(IRequestExceptionAction<,>),
   typeof(INotificationHandler<>),
 };

      foreach (var mediatrOpenType in mediatrOpenTypes)
      {
         builder
           .RegisterAssemblyTypes(_assemblies.ToArray())
           .AsClosedTypesOf(mediatrOpenType)
           .AsImplementedInterfaces();
      }
   }

   private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
   {
      // NOTE: Add any development only services here
      builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
        .InstancePerLifetimeScope();
   }

   private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
   {
      // NOTE: Add any production only services here
      builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
        .InstancePerLifetimeScope();
   }
}