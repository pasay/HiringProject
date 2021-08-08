using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Companies.Responses;
using HiringProject.Model.Queries.Companies;
using MapsterMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Companies
{
    public class GetCompanyFromIdQueryHandler : IRequestHandler<GetCompanyFromIdQuery, CompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetCompanyFromIdQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyInfoResponse> Handle(GetCompanyFromIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);

            return _mapper.Map<CompanyInfoResponse>(result);
        }
    }
}
