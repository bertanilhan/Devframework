using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Notsis.Entities.Concrete;

namespace Notsis.Business.ValidationRules.FluentValidation
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p=> p.ProductName).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.ProductName).Length(2, 20);
            //RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);
            //RuleFor(p => p.ProductName).Must(StartWithA);
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
