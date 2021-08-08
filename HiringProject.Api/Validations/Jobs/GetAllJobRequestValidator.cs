using FluentValidation;
using HiringProject.Model.Controllers.Jobs.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class GetAllJobRequestValidator : AbstractValidator<GetAllJobRequest>
    {
        public GetAllJobRequestValidator()
        {
            RuleFor(r => r.CompanyId)
                .NotEmpty()
                ;
        }
    }
}
