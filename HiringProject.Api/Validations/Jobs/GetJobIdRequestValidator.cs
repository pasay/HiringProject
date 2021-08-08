using FluentValidation;
using HiringProject.Model.Controllers.Jobs.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class GetJobIdRequestValidator : AbstractValidator<GetJobIdRequest>
    {
        public GetJobIdRequestValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
