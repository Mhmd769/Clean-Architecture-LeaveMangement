using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.Excepetion;
using HR.LeaveMangement.Application.Feature.LeaveType.Commands.UpdateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Feature.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandlers : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandlers(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var LeaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if(LeaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType),request.Id);

            await _leaveTypeRepository.DeleteAsync(LeaveTypeToDelete);

            return Unit.Value;

        }
    }
}
