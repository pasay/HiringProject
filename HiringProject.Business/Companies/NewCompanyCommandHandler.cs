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
    public class NewCompanyCommandHandler : IRequestHandler<NewCompanyCommand, CompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public NewCompanyCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyInfoResponse> Handle(NewCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = (await _unitOfWork.CompanyRepository.FirstOrDefaultAsync(p => p.PhoneNumber == request.PhoneNumber));
            if (company != null)
            {
                throw new AlreadyExistsException(nameof(request.PhoneNumber), request.PhoneNumber);
            }
            company = _mapper.Map<Company>(request);
            //TODO: Rules eklenecek.
            var result = await _unitOfWork.CompanyRepository.AddAsync(company);

            return _mapper.Map<CompanyInfoResponse>(result);
        }
    }
}
