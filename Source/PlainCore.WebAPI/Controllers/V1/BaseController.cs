using Microsoft.AspNetCore.Mvc;
using PlainCore.Core.CQS.Base;
using PlainCore.Core.Externals.Dispatcher;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Controllers.V1
{
    public class BaseController : Controller
    {
        protected readonly IContainer container;
        protected readonly ICommandBus commandBus;
        protected readonly IQueryParser parser;
        //protected readonly IWebAuthorizationService webAuthorizationService;
        //protected IApplicationContext applicationContext { get { return this.container.GetInstance<IApplicationContext>(); } }

        public BaseController(IContainer container)
        {
            this.container = container;
            //this.webAuthorizationService = container.GetInstance<IWebAuthorizationService>();
            this.commandBus = container.GetInstance<ICommandBus>();
            this.parser = container.GetInstance<IQueryParser>();
        }

        public IActionResult WebApiCommandDispatcher<T>(T command) where T : ICommand
        {
            if (ModelState.IsValid)
            {
                ValidationResult validationResult = commandBus.Validate(command);

                if (validationResult.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (!result.Success)
                    {
                        return BadRequest(result.Errors);
                    }
                }
                else
                {
                    return BadRequest(validationResult.Errors);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        public async Task<IActionResult> WebApiCommandDispatcherAsync<T>(T command) where T : ICommand
        {
            if (ModelState.IsValid)
            {
                ValidationResult validationResult = commandBus.Validate(command);

                if (validationResult.IsValid)
                {
                    var result = await commandBus.SubmitAsync(command);
                    if (!result.Success)
                        return BadRequest(result.Errors);
                    else
                        return Ok(result);
                }
                else
                {
                    return BadRequest(validationResult.Errors);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public R WebApiQueryParser<Q, R>(Q query) where Q : IQuery<R>
        {
            R result = parser.Process(query);
            return result;
        }
    }
}
