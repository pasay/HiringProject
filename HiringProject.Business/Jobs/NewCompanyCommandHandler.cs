using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers.Jobs.Responses;
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
    public class NewJobCommandHandler : IRequestHandler<NewJobCommand, JobInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public NewJobCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobInfoResponse> Handle(NewJobCommand request, CancellationToken cancellationToken)
        {
            var company = (await _unitOfWork.CompanyRepository.FirstOrDefaultAsync(p => p.Id == request.CompanyId));
            if (company == null)
            {
                throw new DataNotFoundException(nameof(request.CompanyId), request.CompanyId);
            }
            var job = _mapper.Map<Job>(request);
            //TODO: Rules eklenecek.
            var result = await _unitOfWork.JobRepository.AddAsync(job);

            return _mapper.Map<JobInfoResponse>(result);
        }
    }
}
