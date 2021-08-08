using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Queries.Jobs;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Jobs
{
    public class GetAllJobsFromCompanyIdQueryHandler : IRequestHandler<GetAllJobsFromCompanyIdQuery, List<JobInfoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetAllJobsFromCompanyIdQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<JobInfoResponse>> Handle(GetAllJobsFromCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.CompanyId);
            if (company == null)
            {
                throw new KeyNotFoundException($"{nameof(request.CompanyId)}[{request.CompanyId}] not found.");
            }

            var result = (await _unitOfWork.JobRepository.GetAsync(p=> p.CompanyId == request.CompanyId)).ToList();

            return _mapper.Map<List<JobInfoResponse>>(result);
        }
    }
}
