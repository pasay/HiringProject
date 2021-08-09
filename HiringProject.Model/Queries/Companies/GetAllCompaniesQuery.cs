using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;
using System.Collections.Generic;

namespace HiringProject.Model.Queries.Companies
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyInfoResponse>>
    {
    }
}
