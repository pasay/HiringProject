using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Commands.ForbiddenWords
{
    public class DeleteForbiddenWordCommand : IRequest<ForbiddenWordInfoResponse>
    {
        public string Word { get; set; }
    }
}
