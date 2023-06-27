using FluentValidation.UI.Models;

namespace FluentValidation.UI.FluentValidations
{
    public class ProductValidator : AbstractValidator<Products>
    {
        public ProductValidator()
        {
            RuleFor(i => i.ProductName).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
            RuleFor(i => i.Stock).Must(ExistStock).WithMessage("Stok alanı sıfırdan büyük olmalıdır.");
        }
        private bool ExistStock(int number)
        {
            if (number < 1)
                return false;

            return true;
        }
    }
}
