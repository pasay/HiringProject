using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;

namespace HiringProject.Model.Queries.Companies
{
    public class GetCompanyFromIdQuery : IRequest<CompanyInfoResponse>
    {
        public string Id { get; set; }
    }
}
