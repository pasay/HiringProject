using FluentValidation;
using HiringProject.Model.Controllers.ForbiddenWords.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class PostForbiddenWordRequestValidator : AbstractValidator<PostForbiddenWordRequest>
    {
        public PostForbiddenWordRequestValidator()
        {
            RuleFor(r => r.Word)
                .NotEmpty()
                .MinimumLength(2)
                ;
        }
    }
}
