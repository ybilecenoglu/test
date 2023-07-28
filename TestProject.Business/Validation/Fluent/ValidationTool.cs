using FluentValidation;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business.Validation.Fluent
{
    public class ValidationTool
    {
        public static void FluentValidation(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var validateResult = validator.Validate(context);
            if (!validateResult.IsValid)
            {
                throw new ValidationException(validateResult.Errors);
                
            }
        }
    }
}
