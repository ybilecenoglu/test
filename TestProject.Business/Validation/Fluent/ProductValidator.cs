using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Validation.Fluent
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            //RuleFor(p => p.UnitPrice).Must(m => int.TryParse(m.ToString(), out var value) && value > 0).WithMessage("Sadece rakam girilmedilir.");
        }
    }
}
