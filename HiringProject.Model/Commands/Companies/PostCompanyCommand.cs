using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;

namespace HiringProject.Model.Commands.Companies
{
    public class PostCompanyCommand : IRequest<CompanyInfoResponse>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int RemainPublishJobCount { get; set; } = 2;
    }
}
