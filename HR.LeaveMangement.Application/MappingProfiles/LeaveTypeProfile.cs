using AutoMapper;
using HR.LeaveMangement.Application.Feature.LeaveType.Commands.CreateLeaveType;
using HR.LeaveMangement.Application.Feature.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypeDetails;
using HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.MappingProfiles
{
    public class LeaveTypeProfile:Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto,LeaveType>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();

        }
    }
}
