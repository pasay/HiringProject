using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;
using System.Collections.Generic;

namespace HiringProject.Model.Queries.ForbiddenWords
{
    public class GetAllForbiddenWordsQuery : IRequest<List<ForbiddenWordInfoResponse>>
    {
    }
}
