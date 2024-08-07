﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Excepetion
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name,object key) : base($"{name} ({key} was not found)") 
        {
        }
    }
}
