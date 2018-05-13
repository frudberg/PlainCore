using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlainCore.Core.CQS.Base;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.Externals;
using PlainCore.Core.Externals.Dispatcher;
using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Messages;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Dispatcher.Dispatchers;
using PlainCore.Infrastructure.DAL.EF;
using PlainCore.Infrastructure.Identities;
using PlainCore.Infrastructure.Messages;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Infrastructure.IoC
{
    public class StructureMapDefaultRegistry : Registry
    {
        public StructureMapDefaultRegistry()
        {
            Scan(
               scan =>
               {
                   scan.TheCallingAssembly();
                   scan.WithDefaultConventions();
                   scan.AssemblyContainingType<ICommand>();
                   scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                   scan.ConnectImplementationsToTypesClosing(typeof(IValidationHandler<>));
                   scan.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
               });

            For<ICommandBus>().Use<DefaultCommandBus>().ContainerScoped();
            For<IQueryParser>().Use<DefaultQueryParser>().ContainerScoped();
            For<ApplicationUserManager>().Use<ApplicationUserManager>().ContainerScoped();

            For<IIdentityUserManager>().Use(x => x.GetInstance<ApplicationUserManager>());
            For<IIdentityUserManagerRead>().Use(x => x.GetInstance<ApplicationUserManager>());
            For<IApplicationSignInManager>().Use(x => x.GetInstance<ApplicationSignInManager>());
            For<UserManager<ApplicationUser>>().Use(x => x.GetInstance<ApplicationUserManager>());

            For<IEmailSender>().Use<EmailService>();

            For<DbContextOptions<UnitOfWork>>().Use("Context Options For UnitOfWork", container =>
            {
                Microsoft.Extensions.Configuration.IConfiguration configuration = container.GetInstance<Microsoft.Extensions.Configuration.IConfiguration>();
                var dbContextBuilder = new DbContextOptionsBuilder<UnitOfWork>().UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                return dbContextBuilder.Options;
            });

            For<IUnitOfWork>().Use<UnitOfWork>().ContainerScoped();
        }
    }
}
