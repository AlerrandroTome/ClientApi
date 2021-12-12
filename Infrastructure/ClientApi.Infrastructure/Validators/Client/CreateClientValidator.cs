using ClientApi.Core.Dtos.Clients;
using FluentValidation;

namespace ClientApi.Infrastructure.Validators.Client
{
    public class CreateClientValidator : AbstractValidator<CreateClientDto>
    {
        public CreateClientValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(0, 200);
            RuleFor(p => p.BirthDate).NotEmpty();
            RuleFor(p => p.CityId).NotEmpty();
        }
    }
}
