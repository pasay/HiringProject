﻿using HiringProject.Data.Repositories;
using HiringProject.Model.Commands.ForbiddenWords;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
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
    public class DeleteForbiddenWordCommandHandler : IRequestHandler<DeleteForbiddenWordCommand, ForbiddenWordInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public DeleteForbiddenWordCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ForbiddenWordInfoResponse> Handle(DeleteForbiddenWordCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ForbiddenWordRepository.DeleteAsync(p=> p.Word == request.Word);

            return _mapper.Map<ForbiddenWordInfoResponse>(result);
        }
    }
}
