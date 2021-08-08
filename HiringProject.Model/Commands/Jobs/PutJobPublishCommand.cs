﻿using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Commands.Jobs
{
    public class PutJobPublishCommand : IRequest<JobInfoResponse>
    {
        public string Id { get; set; }
        public DateTime TimeToLive { get; set; }
    }
}
