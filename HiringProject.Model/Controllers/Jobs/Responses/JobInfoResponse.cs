using System;

namespace HiringProject.Model.Controllers.Jobs.Responses
{
    public class JobInfoResponse
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime TimeToLive { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
