using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Linq;
using TestProject.Business.Validation.Fluent;

namespace TestProject.Business.Aspect.Postsharp
{
    [Serializable] //Aspect kullanılması için compailer içerisinde serializable edilmesi için kullandık.
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        //Methoda girdiğinde validation işlemlerini yap
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Validator type vererek bir instance olustur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //AbstractValidator hangi tip kullanacağını bildirdik.
            var entities = args.Arguments.Where(t => t.GetType() == entityType); //Gelen argümanlar içerisinde validasyon yapacağımız sınıfınla eşleşen elemanları aldık.

            foreach (var entity in entities)
            {
                ValidationTool.FluentValidation(validator, entity);
            }
        }
    }
}
