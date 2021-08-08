﻿using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using HiringProject.Model.Controllers.Jobs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Model.Queries.ForbiddenWords
{
    public class GetForbiddenWordQuery : IRequest<ForbiddenWordInfoResponse>
    {
        public string Word { get; set; }
    }
}
