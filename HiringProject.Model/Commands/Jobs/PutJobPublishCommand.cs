using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System;

namespace HiringProject.Model.Commands.Jobs
{
    public class PutJobPublishCommand : IRequest<JobInfoResponse>
    {
        public string Id { get; set; }
        public DateTime TimeToLive { get; set; }
    }
}
