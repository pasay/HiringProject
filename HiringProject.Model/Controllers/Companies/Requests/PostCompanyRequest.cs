using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Controllers.Companies.Requests
{
    public class PostCompanyRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxPublishJobCount { get; set; }
    }
}
