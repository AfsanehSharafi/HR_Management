using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LeaveRequestRepository:GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbcontext;
        public LeaveRequestRepository(LeaveManagementDbContext dbcontext)
            : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved= ApprovalStatus;
            _dbcontext.Entry(leaveRequest).State = EntityState.Modified;
            return _dbcontext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
        {
            var leaveRequest = await _dbcontext.LeaveRequests
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync(I=>I.Id == Id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbcontext.LeaveRequests
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }
    }
}
