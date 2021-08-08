using FluentValidation;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class GetForbiddenWordRequestValidator : AbstractValidator<GetForbiddenWordRequest>
    {
        public GetForbiddenWordRequestValidator()
        {
            RuleFor(r => r.Word)
                .NotEmpty()
                .MinimumLength(2)
                ;
        }
    }
}
