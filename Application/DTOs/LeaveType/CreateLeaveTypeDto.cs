﻿using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto:BaseDto, ILeaveTypeDto
    {

        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
