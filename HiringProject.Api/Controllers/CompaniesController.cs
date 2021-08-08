using HiringProject.Model.Commands.Companies;
using HiringProject.Model.Controllers.Companies.Requests;
using HiringProject.Model.Controllers.Companies.Responses;
using HiringProject.Model.Queries.Companies;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompaniesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(List<CompanyInfoResponse>))]
        public async Task<IActionResult> Get()
        {
            var inRequest = new GetAllCompaniesQuery();
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(CompanyInfoResponse))]
        public async Task<IActionResult> Get([FromRoute] GetCompanyIdRequest request)
        {
            var inRequest = _mapper.Map<GetCompanyFromIdQuery>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyIdRequest request)
        {
            var inRequest = _mapper.Map<DeleteCompanyFromIdCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CompanyInfoResponse))]
        public async Task<IActionResult> Post([FromBody] PostCompanyRequest request)
        {
            var inRequest = _mapper.Map<NewCompanyCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }
    }
}
