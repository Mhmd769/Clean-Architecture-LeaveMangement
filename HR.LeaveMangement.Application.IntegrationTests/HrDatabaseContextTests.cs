using HR.LeaveMangement.Domain;
using HR.LeaveMangment.Persistence.DataBasecontext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveMangement.Application.IntegrationTests
{
    public class HrDatabaseContextTests
    {
        private HrDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _hrDatabaseContext=new HrDatabaseContext(dbOptions);

        }
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var leaveType = new LeaveType
            {
                //arrange
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };
            
            //Acts
           await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
           await _hrDatabaseContext.SaveChangesAsync();

            //assert

            leaveType.DateCreated.ShouldNotBeNull();
        }
        public async void Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                //arrange
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            //Acts
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //assert

            leaveType.DateCreated.ShouldNotBeNull();

        }
    }
}