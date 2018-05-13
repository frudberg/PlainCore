using PlainCore.Core.CQS.Users.Queries;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using PlainCore.Core.CQS.Base;
using PlainCore.Core.Externals.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PlainCore.Core.Helpers.UOWExtensions;
using PlainCore.Core.Helpers.Microsoft.DataTransfer.Basics;
using PlainCore.Core.Externals;

namespace PlainCore.Core.CQS.Users.QueryHandlers
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<UserDTO>>
    {
        private IUnitOfWork unitOfWork;
        private IApplicationContext applicationContext;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            this.unitOfWork = unitOfWork;
            this.applicationContext = applicationContext;
        }

        public IList<UserDTO> Handle(GetAllUsersQuery query)
        {
            Guard.NotNull<GetAllUsersQuery>("GetAllUsersQuery", query);

            // Just and example of how to use the IApplicationContext.
            var currentUser = applicationContext.CurrentApplicationUser;

            return unitOfWork.UsersDBSet.GetUsersAsDTO();
        }
    }
}
