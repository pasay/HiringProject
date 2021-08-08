using FluentValidation;
using HiringProject.Model.Controllers.Jobs.Requests;
using System;

namespace Morhipo.Marketplace.External.API.Validations.Jobs
{
    public class PostJobRequestValidator : AbstractValidator<PostJobRequest>
    {
        public PostJobRequestValidator()
        {

            RuleFor(r => r.CompanyId)
                .NotEmpty()
                .GreaterThan(0)
                ;

            RuleFor(r => r.Position)
                .NotEmpty()
                ;

            RuleFor(r => r.Description)
                .NotEmpty()
                ;

            RuleFor(r => r.TimeToLive)
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                ;
        }
    }
}
