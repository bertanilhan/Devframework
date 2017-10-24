using System;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Notsis.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Notsis.Core.Utilities.IoC;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Notsis.Core.Aspects.Postsharp.Validation
{
    [PSerializable]
    public class ValidationAspect:OnMethodBoundaryAspect
    {
        private Type _validationType;

        public ValidationAspect(Type validationType)
        {
            _validationType = validationType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(IValidator).IsAssignableFrom(_validationType))
            {
                throw new Exception("Wrong Validation Type");
            }
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            //var validator = (IValidator)Activator.CreateInstance(_validationType);
            var validator = (IValidator) ServiceTool.ServiceProvider.GetService(_validationType);
            var entityType = _validationType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
