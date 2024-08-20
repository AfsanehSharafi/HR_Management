using Application.Contracts.Persistence;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Mocks
{
    public static class MockLeaveRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDay =10,
                    Name="Test Vacation"
                },

                new LeaveType
                {
                    Id = 2,
                    DefaultDay =1,
                    Name="Test Sick"
                },
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
                {

                    leaveTypes.Add(leaveType);
                    return leaveType;
                });
            return mockRepo;
        }
    }
}
