using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;

public class GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationDto>>
{
}