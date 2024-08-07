using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypeDetails
{
    public record GetLeaveTypesDetailsQuery(int Id):IRequest<LeaveTypeDetailsDto>;
}
