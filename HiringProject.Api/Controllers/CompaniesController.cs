using HiringProject.Model.Controllers.Companies.Requests;
using HiringProject.Model.Controllers.Companies.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        [HttpGet("all")]
        public async Task<ActionResult<List<CompanyInfoResponse>>> Get()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CompanyInfoResponse>> Get([FromRoute] GetCompanyIdRequest request)
        {
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<CompanyInfoResponse>> Delete([FromRoute] DeleteCompanyIdRequest request)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CompanyInfoResponse>> Post([FromBody] PostCompanyRequest request)
        {
            return Ok();
        }
    }
}
