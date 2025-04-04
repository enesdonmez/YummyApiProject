using FluentValidation;
using Yummy.Api.Entitites;

namespace Yummy.Api.ValidationRules;

public class ReservationValidator : AbstractValidator<Reservation>
{
    public ReservationValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email boş olamaz")
            .EmailAddress()
            .WithMessage("Email geçerli değil");

        RuleFor(x => x.ReservationDate)
            .NotEmpty()
            .WithMessage("Rezervasyon tarihi boş olamaz")
            .LessThan(DateTime.Now)
            .WithMessage("Rezervasyon tarihi bugünden eski olamaz");

        RuleFor(x => x.ReservationTime)
            .NotEmpty()
            .WithMessage("Rezervasyon saati boş olamaz")
            .LessThan(DateTime.Now.Hour.ToString())
            .WithMessage("Rezervasyon saati şimdiden eski olamaz");

        RuleFor(x => x.CountofPeople)
            .NotEmpty()
            .WithMessage("Kişi sayısı boş olamaz")
            .GreaterThan(0)
            .WithMessage("Kişi sayısı 0 dan büyük olmalıdır");

        RuleFor(x => x.ReservationStatus)
            .NotNull()
            .NotEmpty()
            .WithMessage("Rezervasyon durumu boş olamaz");

    }
}
