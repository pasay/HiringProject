using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using HiringProject.Model.Queries.ForbiddenWords;
using MapsterMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.ForbiddenWords
{
    public class GetForbiddenWordFromIdQueryHandler : IRequestHandler<GetForbiddenWordQuery, ForbiddenWordInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetForbiddenWordFromIdQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ForbiddenWordInfoResponse> Handle(GetForbiddenWordQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ForbiddenWordRepository.FirstOrDefaultAsync(p => p.Word == request.Word);

            return _mapper.Map<ForbiddenWordInfoResponse>(result);
        }
    }
}
