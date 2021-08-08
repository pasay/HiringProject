using HiringProject.Business.Rules;
using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Enums;
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
    public class PostJobCommandHandler : IRequestHandler<PostJobCommand, JobInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IJobQualityRuleCalculator _jobQualityRuleCalculator;

        public PostJobCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork, IJobQualityRuleCalculator jobQualityRuleCalculator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jobQualityRuleCalculator = jobQualityRuleCalculator;
        }

        public async Task<JobInfoResponse> Handle(PostJobCommand request, CancellationToken cancellationToken)
        {
            var company = (await _unitOfWork.CompanyRepository.GetByIdAsync(request.CompanyId));
            if (company == null)
            {
                throw new DataNotFoundException(nameof(request.CompanyId), request.CompanyId);
            }
            var job = _mapper.Map<Job>(request);
            job.QualityScore = await _jobQualityRuleCalculator.CalculateQuality(request);
            job.JobStatus = (int)JobStatusEnum.Created;

            var result = await _unitOfWork.JobRepository.AddAsync(job);

            return _mapper.Map<JobInfoResponse>(result);
        }
    }
}
