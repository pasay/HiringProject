using HiringProject.Business.Rules;
using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.Companies;
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
    public class PutJobPublishCommandHandler : IRequestHandler<PutJobPublishCommand, JobInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMediator _mediator;

        public PutJobPublishCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<JobInfoResponse> Handle(PutJobPublishCommand request, CancellationToken cancellationToken)
        {
            var job = (await _unitOfWork.JobRepository.GetByIdAsync(request.Id));
            if (job == null)
            {
                throw new DataNotFoundException(nameof(request.Id), request.Id);
            }
            if (job.JobStatus != (int)JobStatusEnum.Created)
            {
                throw new PublishJobStatusException(nameof(request.Id), request.Id);
            }
            var company = (await _unitOfWork.CompanyRepository.GetByIdAsync(job.CompanyId));
            if (company == null)
            {
                throw new DataNotFoundException(nameof(job.CompanyId), job.CompanyId);
            }

            job.TimeToLive = DateTime.UtcNow.AddDays(15);
            job.JobStatus = (int)JobStatusEnum.Published;

            await _mediator.Send(new DecrementPublishJobCountCompanyCommand() { Id = job.CompanyId }, cancellationToken);
            var result = await _unitOfWork.JobRepository.UpdateByIdAsync(job.Id, job);

            return _mapper.Map<JobInfoResponse>(result);
        }
    }
}
