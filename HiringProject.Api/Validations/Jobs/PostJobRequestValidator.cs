using FluentValidation;
using HiringProject.Model.Controllers.Jobs.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class PostJobRequestValidator : AbstractValidator<PostJobRequest>
    {
        public PostJobRequestValidator()
        {

            RuleFor(r => r.CompanyId)
                .NotEmpty()
                ;

            RuleFor(r => r.Position)
                .NotEmpty()
                ;

            RuleFor(r => r.Description)
                .NotEmpty()
                ;
        }
    }
}
