using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Controllers.Jobs.Requests
{
    public class PostJobRequest
    {
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime TimeToLive { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
