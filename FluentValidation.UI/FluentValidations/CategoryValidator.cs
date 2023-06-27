using FluentValidation.UI.Models;

namespace FluentValidation.UI.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Categories>
    {
        public CategoryValidator()
        {
            RuleFor(i => i.CategoryName).NotNull().WithMessage("Bu alan zorunlu alandır");

            RuleForEach(i => i.Products).SetValidator(new ProductValidator());
        }

    }
}
