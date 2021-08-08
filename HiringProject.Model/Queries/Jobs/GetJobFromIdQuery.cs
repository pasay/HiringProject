using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Queries.Jobs
{
    public class GetJobFromIdQuery : IRequest<JobInfoResponse>
    {
        public string Id { get; set; }
    }
}
