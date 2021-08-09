using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;

namespace HiringProject.Model.Queries.Jobs
{
    public class GetJobFromIdQuery : IRequest<JobInfoResponse>
    {
        public string Id { get; set; }
    }
}
