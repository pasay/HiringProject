using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Controllers
{
    public class CustomHttpResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
