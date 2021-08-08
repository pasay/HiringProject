using HiringProject.Data.Repositories;
using HiringProject.Model.Commands.Companies;
using HiringProject.Model.Controllers.Companies.Responses;
using MapsterMapper;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Companies
{
    public class DeleteCompanyFromIdCommandHandler : IRequestHandler<DeleteCompanyFromIdCommand, CompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public DeleteCompanyFromIdCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyInfoResponse> Handle(DeleteCompanyFromIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CompanyRepository.DeleteByIdAsync(request.Id);

            return _mapper.Map<CompanyInfoResponse>(result);
        }
    }
}
