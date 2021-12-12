using ClientApi.Core.Dtos.Cities;
using FluentValidation;

namespace ClientApi.Infrastructure.Validators.City
{
    public class CreateCityValidator : AbstractValidator<CreateCityDto>
    {
        public CreateCityValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(1, 100);
            RuleFor(p => p.State).NotEmpty().Length(1, 100);
        }
    }
}
