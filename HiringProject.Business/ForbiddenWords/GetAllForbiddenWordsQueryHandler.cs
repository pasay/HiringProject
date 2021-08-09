using HiringProject.Data.Repositories;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using HiringProject.Model.Queries.ForbiddenWords;
using MapsterMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HiringProject.Business.ForbiddenWords
{
    public class GetAllForbiddenWordsQueryHandler : IRequestHandler<GetAllForbiddenWordsQuery, List<ForbiddenWordInfoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GetAllForbiddenWordsQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ForbiddenWordInfoResponse>> Handle(GetAllForbiddenWordsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _unitOfWork.ForbiddenWordRepository.GetAsync()).ToList();

            return _mapper.Map<List<ForbiddenWordInfoResponse>>(result);
        }
    }
}
