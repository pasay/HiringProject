using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Queries.Jobs;
using MapsterMapper;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.Jobs
{
    public class GetJobFromIdQueryHandler : IRequestHandler<GetJobFromIdQuery, JobInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetJobFromIdQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobInfoResponse> Handle(GetJobFromIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.JobRepository.GetByIdAsync(request.Id);

            return _mapper.Map<JobInfoResponse>(result);
        }
    }
}
