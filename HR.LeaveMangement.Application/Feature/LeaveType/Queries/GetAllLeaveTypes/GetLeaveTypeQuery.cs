using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
    public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>
    {
    }
}
