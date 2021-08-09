using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Companies.Responses;
using HiringProject.Model.Queries.Companies;
using MapsterMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Companies
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyInfoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetAllCompaniesQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CompanyInfoResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var result = (await _unitOfWork.CompanyRepository.GetAsync()).ToList();

            return _mapper.Map<List<CompanyInfoResponse>>(result);
        }
    }
}
