using HiringProject.Model.Commands.Jobs;
using HiringProject.Model.Controllers.Jobs.Requests;
using HiringProject.Model.Controllers.Jobs.Responses;
using HiringProject.Model.Queries.Jobs;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public JobsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<JobInfoResponse>))]
        public async Task<IActionResult> Get()
        {
            var inRequest = new GetAllJobsQuery();
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpGet("all/{CompanyId}")]
        [ProducesResponseType(200, Type = typeof(List<JobInfoResponse>))]
        public async Task<IActionResult> Get([FromRoute] GetAllJobRequest request)
        {
            var inRequest = _mapper.Map<GetAllJobsFromCompanyIdQuery>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(JobInfoResponse))]
        public async Task<IActionResult> Get([FromRoute] GetJobIdRequest request)
        {
            var inRequest = _mapper.Map<GetJobFromIdQuery>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteJobIdRequest request)
        {
            var inRequest = _mapper.Map<DeleteJobFromIdCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(JobInfoResponse))]
        public async Task<IActionResult> Post([FromBody] PostJobRequest request)
        {
            var inRequest = _mapper.Map<PostJobCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpPut("Publish/{Id}")]
        [ProducesResponseType(200, Type = typeof(JobInfoResponse))]
        public async Task<IActionResult> Put([FromRoute] PutJobPublishRequest request)
        {
            var inRequest = _mapper.Map<PutJobPublishCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }
    }
}
