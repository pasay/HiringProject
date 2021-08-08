using HiringProject.Model.Controllers.Companies.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Commands.Companies
{
    public class DeleteCompanyFromIdCommand : IRequest<CompanyInfoResponse>
    {
        public string Id { get; set; }
    }
}
