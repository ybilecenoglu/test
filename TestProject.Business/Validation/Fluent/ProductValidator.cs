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
            //Nullable validator
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.Discontinued).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();

            //Special validator
           
            
        }
    }
}
