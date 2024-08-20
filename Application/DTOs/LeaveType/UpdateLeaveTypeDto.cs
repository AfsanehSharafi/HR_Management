﻿using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto:BaseDto,ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }

        public static implicit operator UpdateLeaveTypeDto(LeaveTypeDto v)
        {
            throw new NotImplementedException();
        }
    }
}
