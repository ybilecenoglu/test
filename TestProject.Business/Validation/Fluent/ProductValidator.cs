using FluentValidation;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Validation.Fluent
{
    public class ProductValidator : AbstractValidator<Product>
    {
        
        public ProductValidator()
        {
            //Nullable validator
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();

            //Special validator
            //RuleFor(p => p.ProductName).Must(p => p.StartsWith("A")).WithMessage("Ürün adı 'A' ile başlamalıdır.");
        }
    }
}
