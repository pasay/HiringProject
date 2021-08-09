using HiringProject.Data.Repositories;
using HiringProject.Model.Commands.ForbiddenWords;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MapsterMapper;
using MediatR;
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
            var result = await _unitOfWork.ForbiddenWordRepository.DeleteExpressionAsync(p => p.Word == request.Word);

            return _mapper.Map<ForbiddenWordInfoResponse>(result);
        }
    }
}
