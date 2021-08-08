using HiringProject.Data.Repositories;
using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers.Jobs.Responses;
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
    public class DeleteJobFromIdCommandHandler : IRequestHandler<DeleteJobFromIdCommand, JobInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public DeleteJobFromIdCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<JobInfoResponse> Handle(DeleteJobFromIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.JobRepository.DeleteAsync(request.Id);

            return _mapper.Map<JobInfoResponse>(result);
        }
    }
}
