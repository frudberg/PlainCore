using Microsoft.AspNetCore.Mvc.Filters;
using PlainCore.Core.Externals;
using PlainCore.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Attributes
{
    public class ApplicationContextActionFilterAttribute : ActionFilterAttribute
    {
        public IContainer container;

        public ApplicationContextActionFilterAttribute(IContainer container)
        {
            this.container = container;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                container.Inject<IApplicationContext>(new WebApplicationContext(context.HttpContext, this.container));
            }
        }
    }

}
