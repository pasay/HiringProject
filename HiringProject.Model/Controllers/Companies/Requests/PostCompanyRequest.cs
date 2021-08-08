namespace HiringProject.Model.Controllers.Companies.Requests
{
    public class PostCompanyRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxPublishJobCount { get; set; } = 2;
    }
}
