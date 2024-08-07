using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.Excepetion;
using HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler :IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database for a specific leave type by ID
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveType == null) {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            // Convert the retrieved entity to a DTO
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            // Return the DTO object
            return data;
        }
    }
}
