using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.Companies;
using HiringProject.Model.Controllers.Companies.Responses;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Companies
{
    public class PutCompanyRemainPublishJobCountCommandHandler : IRequestHandler<PutCompanyRemainPublishJobCountCommand, CompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public PutCompanyRemainPublishJobCountCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyInfoResponse> Handle(PutCompanyRemainPublishJobCountCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new DataNotFoundException(nameof(company.Id), company.Id.ToString());
            }
            company.RemainPublishJobCount = request.RemainPublishJobCount;
            var result = await _unitOfWork.CompanyRepository.UpdateByIdAsync(company.Id, company);

            return _mapper.Map<CompanyInfoResponse>(result);
        }
    }
}
