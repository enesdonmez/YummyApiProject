using FluentValidation;
using Yummy.Api.Entitites;

namespace Yummy.Api.ValidationRules;

public class MenuItemValidator : AbstractValidator<MenuItem>
{
    public MenuItemValidator()
    {
        RuleFor(x => x.MenuItemName).NotEmpty().WithMessage("İsim alanı boş olamaz");
        RuleFor(x => x.MenuItemName).MinimumLength(2).WithMessage("İsim alanı en az 2 karakterden oluşabilir");
        RuleFor(x => x.MenuItemName).MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakterden oluşabilir");
        RuleFor(x => x.MenuItemDescription).NotEmpty().WithMessage("Açıklama alanı boş olamaz").MinimumLength(5).WithMessage("Açıklama en az 5 karakterden oluşabilir");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş olamaz").GreaterThan(0).WithMessage("Fiyat 0 dan büyük olmalı");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş olamaz");

    }
}
