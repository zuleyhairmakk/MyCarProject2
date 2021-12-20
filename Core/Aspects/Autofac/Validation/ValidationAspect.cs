using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
   public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir dogruma sinifi degildir");//gelen tip ivalidator tipinde degilse kizar gonderilen carValidator buraya gelecek
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//carvalidatorun calisma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//carvalidator in tipine esit olan parametreleri bul
            foreach (var entity in entities)//her birini tek tek gez
            {
                ValidationTool.Validate(validator, entity);//validation tool u kullanarak validate et 
            }
        }
    }
}
