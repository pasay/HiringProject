using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Queries.Jobs;
using MapsterMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Jobs
{
    public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, List<JobInfoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetAllJobsQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<JobInfoResponse>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _unitOfWork.JobRepository.GetAsync()).ToList();

            return _mapper.Map<List<JobInfoResponse>>(result);
        }
    }
}
