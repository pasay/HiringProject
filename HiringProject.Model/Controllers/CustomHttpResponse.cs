using System.Net;

namespace HiringProject.Model.Controllers
{
    public class CustomHttpResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
