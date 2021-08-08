using HiringProject.Business.Rules;
using HiringProject.Data.Models;
using HiringProject.Data.Repositories;
using HiringProject.Exceptions;
using HiringProject.Model.Commands.ForbiddenWords;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
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

namespace HiringProject.Business.ForbiddenWords
{
    public class PostForbiddenWordCommandHandler : IRequestHandler<PostForbiddenWordCommand, ForbiddenWordInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public PostForbiddenWordCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ForbiddenWordInfoResponse> Handle(PostForbiddenWordCommand request, CancellationToken cancellationToken)
        {
            var forbiddenWord = (await _unitOfWork.ForbiddenWordRepository.FirstOrDefaultAsync(p => p.Word == request.Word));
            if (forbiddenWord != null)
            {
                throw new AlreadyExistsException(nameof(request.Word), request.Word);
            }
            var job = _mapper.Map<ForbiddenWord>(request);

            var result = await _unitOfWork.ForbiddenWordRepository.AddAsync(job);

            return _mapper.Map<ForbiddenWordInfoResponse>(result);
        }
    }
}
