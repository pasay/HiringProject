using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Commands.Jobs
{
    public class NewJobCommand : IRequest<JobInfoResponse>
    {
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime TimeToLive { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
