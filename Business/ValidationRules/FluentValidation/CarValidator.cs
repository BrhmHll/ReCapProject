using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.Description).NotEmpty();
			RuleFor(c => c.Description).MinimumLength(10);
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(c => c.DailyPrice).GreaterThan(0);
			RuleFor(c => c.Description).Must(TestFunciton);
			RuleFor(c => c.ModelYear).GreaterThan(1950);
		}

		private bool TestFunciton(string arg)
		{
			return arg.StartsWith("A");
		}
	}
}
