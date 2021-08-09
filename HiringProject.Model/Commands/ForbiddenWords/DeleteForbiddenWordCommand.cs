using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;

namespace HiringProject.Model.Commands.ForbiddenWords
{
    public class DeleteForbiddenWordCommand : IRequest<ForbiddenWordInfoResponse>
    {
        public string Word { get; set; }
    }
}
