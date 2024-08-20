using Application.Contracts.Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LeaveTypeRepository:GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbcontext;
        public LeaveTypeRepository(LeaveManagementDbContext dbcontext)
            : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
