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

namespace PlainCore.Core.CQS.Users.QueryHandlers
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<UserDTO>>
    {
        private IUnitOfWork unitOfWork;
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<UserDTO> Handle(GetAllUsersQuery query)
        {
            return unitOfWork.UsersDBSet.GetUsersAsDTO();
        }
    }
}
