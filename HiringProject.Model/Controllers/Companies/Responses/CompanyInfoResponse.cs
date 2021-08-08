namespace HiringProject.Model.Controllers.Companies.Responses
{
    public class CompanyInfoResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxPublishJobCount { get; set; } = 2;
    }
}
