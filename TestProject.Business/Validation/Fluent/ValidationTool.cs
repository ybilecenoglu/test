using FluentValidation;

namespace TestProject.Business.Validation.Fluent
{
    public class ValidationTool
    {
        public static void FluentValidation(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
