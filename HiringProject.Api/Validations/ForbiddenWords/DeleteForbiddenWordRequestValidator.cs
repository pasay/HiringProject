using FluentValidation;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class DeleteForbiddenWordRequestValidator : AbstractValidator<DeleteForbiddenWordRequest>
    {
        public DeleteForbiddenWordRequestValidator()
        {
            RuleFor(r => r.Word)
                .NotEmpty()
                .MinimumLength(2)
                ;
        }
    }
}
