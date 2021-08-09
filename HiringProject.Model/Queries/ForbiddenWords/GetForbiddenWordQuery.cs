using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;

namespace HiringProject.Model.Queries.ForbiddenWords
{
    public class GetForbiddenWordQuery : IRequest<ForbiddenWordInfoResponse>
    {
        public string Word { get; set; }
    }
}
