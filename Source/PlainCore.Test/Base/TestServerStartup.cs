using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlainCore.Test.IoC;
using PlainCore.WebAPI;
using System;
using StructureMap;
using System.Collections.Generic;
using System.Text;
using PlainCore.Infrastructure.DAL.EF;
using PlainCore.Core.Externals.Repositories;

namespace PlainCore.Test.Base
{
    public class TestServerStartup : Startup
    {
        public TestServerStartup(IHostingEnvironment env) : base(env)
        {
        }

        public override IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = StructureMapContainerInit.InitializeContainer();
            container.Inject<IConfigurationRoot>(Configuration);
            container.Inject<IConfiguration>(Configuration);
            container.Populate(services);
            return container.GetInstance<IServiceProvider>();
        }
    }
}
