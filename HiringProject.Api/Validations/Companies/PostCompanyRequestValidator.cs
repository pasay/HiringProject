using FluentValidation;
using HiringProject.Model.Controllers.Companies.Requests;

namespace Morhipo.Marketplace.External.API.Validations.Categories
{
    public class PostCompanyRequestValidator : AbstractValidator<PostCompanyRequest>
    {
        public PostCompanyRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                ;

            RuleFor(r => r.Address)
                .NotEmpty()
                ;

            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .Length(10, 12) //Daha detayl� regex yap�labilir. �imdilik 10(Yerel) karakter ile 12(Uluslararas�) karakter aras� d���n�lerek hareket edildi.
                ;

            RuleFor(r => r.RemainPublishJobCount)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
