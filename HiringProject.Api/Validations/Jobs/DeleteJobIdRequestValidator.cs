using FluentValidation;
using HiringProject.Model.Controllers.Jobs.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class DeleteJobIdRequestValidator : AbstractValidator<DeleteJobIdRequest>
    {
        public DeleteJobIdRequestValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
