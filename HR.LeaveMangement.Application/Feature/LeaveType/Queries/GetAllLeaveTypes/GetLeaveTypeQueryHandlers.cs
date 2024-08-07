using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandlers : IRequestHandler<GetLeaveTypeQuery,
       List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeQueryHandlers(IMapper mapper ,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //query db
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            //convert data to dto 
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of objects
            return data;
        }
    }
}
