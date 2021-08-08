using System;

namespace HiringProject.Model.Controllers.Jobs.Requests
{
    public class PostJobRequest
    {
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
