using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;

namespace HiringProject.Model.Commands.Companies
{
    public class DeleteCompanyFromIdCommand : IRequest<CompanyInfoResponse>
    {
        public string Id { get; set; }
    }
}
