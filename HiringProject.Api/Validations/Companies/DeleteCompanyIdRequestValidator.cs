using FluentValidation;
using HiringProject.Model.Controllers.Companies.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Categories
{
    public class DeleteCompanyIdRequestValidator : AbstractValidator<DeleteCompanyIdRequest>
    {
        public DeleteCompanyIdRequestValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
