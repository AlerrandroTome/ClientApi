using ClientApi.Core.Dtos.Cities;
using FluentValidation;

namespace ClientApi.Infrastructure.Validators.City
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityDto>
    {
        public UpdateCityValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty().Length(1, 100);
            RuleFor(p => p.State).NotEmpty().Length(1, 100);
        }
    }
}
