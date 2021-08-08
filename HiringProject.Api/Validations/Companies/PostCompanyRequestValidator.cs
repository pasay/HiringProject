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
                .Length(10, 12) //Daha detaylý regex yapýlabilir. Þimdilik 10(Yerel) karakter ile 12(Uluslararasý) karakter arasý düþünülerek hareket edildi.
                ;

            RuleFor(r => r.RemainPublishJobCount)
                .NotEmpty()
                .GreaterThan(0)
                ;
        }
    }
}
