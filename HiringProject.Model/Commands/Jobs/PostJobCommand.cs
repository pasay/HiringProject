using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;

namespace HiringProject.Model.Commands.Jobs
{
    public class PostJobCommand : IRequest<JobInfoResponse>
    {
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
