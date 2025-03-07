using FluentValidation;
using Yummy.Api.Entitites;

namespace Yummy.Api.ValidationRules;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email boş olamaz")
            .EmailAddress()
            .WithMessage("Email geçerli değil");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Konu boş olamaz")
            .MinimumLength(5)
            .WithMessage("Adres en az 5 karakterden oluşabilir")
            .MaximumLength(100)
            .WithMessage("Adres en fazla 100 karakterden oluşabilir");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Telefon numarası boş olamaz")
            .MinimumLength(10)
            .WithMessage("Telefon numarası en az 10 karakterden oluşabilir");

        RuleFor(x => x.OpenHours)
            .NotEmpty()
            .WithMessage("Açılış saatleri boş olamaz");

        RuleFor(x => x.MapLocation)
            .NotEmpty()
            .WithMessage("Konum boş olamaz");
    }
}
