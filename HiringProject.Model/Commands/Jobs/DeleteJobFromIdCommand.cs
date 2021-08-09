using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;

namespace HiringProject.Model.Commands.Jobs
{
    public class DeleteJobFromIdCommand : IRequest<JobInfoResponse>
    {
        public string Id { get; set; }
    }
}
