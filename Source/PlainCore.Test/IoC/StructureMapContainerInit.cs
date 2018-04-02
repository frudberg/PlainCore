using PlainCore.Infrastructure.IoC;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Test.IoC
{
    internal static class StructureMapContainerInit
    {
        public static IContainer InitializeContainer()
        {
            var defaultRegistry = new DefaultRegistry();
            return new Container(c => c.AddRegistry(defaultRegistry));
        }
    }

    internal class DefaultRegistry : StructureMapDefaultRegistry
    {
        public DefaultRegistry() : base()
        {
        }
    }
}
