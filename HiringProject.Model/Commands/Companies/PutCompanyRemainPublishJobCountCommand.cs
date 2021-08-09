using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;

namespace HiringProject.Model.Commands.Companies
{
    public class PutCompanyRemainPublishJobCountCommand : IRequest<CompanyInfoResponse>
    {
        public string Id { get; set; }
        public int RemainPublishJobCount { get; set; }
    }
}
