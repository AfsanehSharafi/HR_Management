using Application.DTOs.LeaveAllocation;
using Application.Features.LeaveAllocations.Handlers.Commands;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand
        : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
