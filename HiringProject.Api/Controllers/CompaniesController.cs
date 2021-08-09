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
    /// <summary>
    /// Şirket bilgilerine ait işlemler için kullanılır
    /// </summary>
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

        /// <summary>
        /// Tanımlı olan tüm şirketlerin bilgisini verir.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CompanyInfoResponse>))]
        public async Task<IActionResult> Get()
        {
            var inRequest = new GetAllCompaniesQuery();
            var result = await _mediator.Send(inRequest);
            return Ok(result);
        }

        /// <summary>
        /// ID bilgisi verilen şirketin bilgisini verir.
        /// </summary>
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(CompanyInfoResponse))]
        public async Task<IActionResult> Get([FromRoute] GetCompanyIdRequest request)
        {
            var inRequest = _mapper.Map<GetCompanyFromIdQuery>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        /// <summary>
        /// ID bilgisi verilen şirketi siler
        /// </summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyIdRequest request)
        {
            var inRequest = _mapper.Map<DeleteCompanyFromIdCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }


        /// <summary>
        /// Yeni bir şirketi tanımlamak için kullanılır
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CompanyInfoResponse))]
        public async Task<IActionResult> Post([FromBody] PostCompanyRequest request)
        {
            var inRequest = _mapper.Map<PostCompanyCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }

        /// <summary>
        /// ID Bilgisi verilen şirketin ilan yayınlama sayısını günceller.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(CompanyInfoResponse))]
        public async Task<IActionResult> Put([FromBody] PutCompanyRemainPublishJobCountRequest request)
        {
            var inRequest = _mapper.Map<PutCompanyRemainPublishJobCountCommand>(request);
            return Ok(await _mediator.Send(inRequest));
        }
    }
}
