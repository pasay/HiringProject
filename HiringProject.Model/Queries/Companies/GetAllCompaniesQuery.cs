using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Queries.Companies
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyInfoResponse>>
    {
    }
}
