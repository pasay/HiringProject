﻿using HiringProject.Model.Commands.ForbiddenWords;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;
using HiringProject.Model.Controllers.ForbiddenWords.Responses;
using HiringProject.Model.Queries.ForbiddenWords;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForbiddenWordsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ForbiddenWordsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ForbiddenWordInfoResponse>))]
        public async Task<IActionResult> Get()
        {
            var inRequest = new GetAllForbiddenWordsQuery();
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpGet("{Word}")]
        [ProducesResponseType(200, Type = typeof(ForbiddenWordInfoResponse))]
        public async Task<IActionResult> Get([FromRoute] GetForbiddenWordRequest request)
        {
            var inRequest = _mapper.Map<GetForbiddenWordQuery>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpDelete("{Word}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteForbiddenWordRequest request)
        {
            var inRequest = _mapper.Map<DeleteForbiddenWordCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ForbiddenWordInfoResponse))]
        public async Task<IActionResult> Post([FromBody] PostForbiddenWordRequest request)
        {
            var inRequest = _mapper.Map<PostForbiddenWordCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }
    }
}
