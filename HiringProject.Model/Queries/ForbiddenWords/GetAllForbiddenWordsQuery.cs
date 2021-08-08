using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Queries.ForbiddenWords
{
    public class GetAllForbiddenWordsQuery : IRequest<List<ForbiddenWordInfoResponse>>
    {
    }
}
