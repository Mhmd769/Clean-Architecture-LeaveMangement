using HR.LeaveMangement.Domain;

namespace HR.LeaveMangement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository <LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}