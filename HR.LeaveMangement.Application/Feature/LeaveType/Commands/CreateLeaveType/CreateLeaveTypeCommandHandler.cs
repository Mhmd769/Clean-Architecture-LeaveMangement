using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.Excepetion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Any()) {
                throw new BadRequestException("Invalid LeaveType", validationResult);
            }
            //convert to domian entity
            var LeaveTypeCreate = _mapper.Map<Domain.LeaveType>(request);
            //add to db
            await _leaveTypeRepository.CreateAsync(LeaveTypeCreate);
            //return record id
            return LeaveTypeCreate.Id;
        }
    }
}
