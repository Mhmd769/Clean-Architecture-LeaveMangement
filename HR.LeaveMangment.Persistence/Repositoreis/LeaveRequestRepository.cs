﻿using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Domain;
using HR.LeaveMangment.Persistence.DataBasecontext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveMangment.Persistence.Repositoreis
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.leaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.leaveRequests
                .Where(q => q.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.leaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }
    }
}
