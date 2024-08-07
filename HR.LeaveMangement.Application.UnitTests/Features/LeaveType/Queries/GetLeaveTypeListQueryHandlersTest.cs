using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveMangement.Application.MappingProfiles;
using HR.LeaveMangement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.UnitTests.Features.LeaveType.Queries
{
    public class GetLeaveTypeListQueryHandlersTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveTypeListQueryHandlersTest()
        {
            _mockRepo=MockLeaveTypeRepository.GetLeaveTypesMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeQueryHandlers(_mapper,_mockRepo.Object);
            var result = await handler.Handle(new GetLeaveTypeQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);   
        }
    }
}
