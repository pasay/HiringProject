using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;

namespace HiringProject.Model.Commands.ForbiddenWords
{
    public class PostForbiddenWordCommand : IRequest<ForbiddenWordInfoResponse>
    {
        public string Word { get; set; }
    }
}
