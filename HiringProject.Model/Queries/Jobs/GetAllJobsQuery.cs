﻿using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System.Collections.Generic;

namespace HiringProject.Model.Queries.Jobs
{
    public class GetAllJobsQuery : IRequest<List<JobInfoResponse>>
    {
    }
}
