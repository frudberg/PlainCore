using PlainCore.Core.Externals;
using PlainCore.Infrastructure.IoC;
using PlainCore.WebAPI.Authentication;
using StructureMap;

namespace PlainCore.WebAPI.IoC
{
    public static class StructureMapContainerInit
    {
        public static IContainer InitializeContainer()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }

    public class DefaultRegistry : StructureMapDefaultRegistry
    {
        #region Constructors and Destructors

        public DefaultRegistry() : base()
        {
            For<IApplicationContext>().Use<WebApplicationContext>();
        }

        #endregion
    }
}
