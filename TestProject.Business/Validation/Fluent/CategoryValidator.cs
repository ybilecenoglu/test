using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Validation.Fluent
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private string _categoryName;
        public CategoryValidator() { 

            RuleFor(x => x.CategoryName).NotEmpty();

            //RuleFor(x => x.CategoryName).MustAsync(async (p, token) =>
            //{

            //});
        }

        public async Task<bool> EqualsCategoryName(string categoryName)
        {
            using (var context = new NorthwindContext())
            {
                var category =  await context.Categories.Where(x => x.CategoryName.Equals(categoryName)).SingleOrDefaultAsync();
                if (category != null)
                {
                    return false;
                }
                else
                    return true;
                
            }
        }
    }
}
