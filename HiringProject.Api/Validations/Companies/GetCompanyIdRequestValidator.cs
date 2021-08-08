using FluentValidation;
using HiringProject.Model.Controllers.Companies.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Categories
{
    public class GetCompanyIdRequestValidator : AbstractValidator<GetCompanyIdRequest>
    {
        public GetCompanyIdRequestValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
