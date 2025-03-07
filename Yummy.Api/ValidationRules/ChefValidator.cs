using FluentValidation;
using Yummy.Api.Entitites;

namespace Yummy.Api.ValidationRules;

public class ChefValidator : AbstractValidator<Chef>
{
    public ChefValidator()
    {
        RuleFor(x => x.NameSurname).NotEmpty().WithMessage("İsim alanı boş olamaz").MinimumLength(5).WithMessage("İsim en az 5 karakterden oluşabilir").MaximumLength(50).WithMessage("isim en fazla 50 karakterden oluşabilir.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan alanı boş olamaz").MinimumLength(1).WithMessage("Ünvan en az 1 karakterden oluşabilir").MaximumLength(50).WithMessage("Ünvan en fazla 50 karakterden oluşabilir.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş olamaz").MinimumLength(5).WithMessage("Açıklama en az 5 karakterden oluşabilir");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş olamaz");
    }
}
