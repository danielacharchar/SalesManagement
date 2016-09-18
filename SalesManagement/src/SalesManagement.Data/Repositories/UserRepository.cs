using SalesManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SalesManagement.Data.Abstract.IRepositories;

namespace SalesManagement.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(SalesManagementContext context)
            : base(context)
        { }
    }
}
