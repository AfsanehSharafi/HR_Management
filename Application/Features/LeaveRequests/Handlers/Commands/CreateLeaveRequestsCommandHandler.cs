using Application.Exceptions;
using Application.Features.LeaveRequests.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure;
using Application.Models;

namespace Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender, IEmailSender emailSender1)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public IEmailSender EmailSender { get; }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Succesdsful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "Ashdev.ir@gmail.com",
                Subject = "LeaveRequest Submited.",
                Body = $"Your LeaveRequest for {request.LeaveRequestDto.StartDate}" +
                $"to {request.LeaveRequestDto.EndDate} " +
                $"has been Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }

            catch (Exception ex) 
            {
                //log
            }


            return response;
        }
    }
}
