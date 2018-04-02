using PlainCore.Infrastructure.IoC;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }

        #endregion
    }
}
