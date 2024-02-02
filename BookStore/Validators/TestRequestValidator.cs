using BookStore.Models.Request;
using FluentValidation;

namespace BookStore.Validators
{
    public class TestRequestValidator : AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            RuleFor(test => test.Id)
                .NotNull()
                .GreaterThan(0)
                .LessThan(10);
            RuleFor(test => test.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(test => test.SomeDate)
                .NotNull()
                .NotEmpty()
                .LessThan(new DateTime(2020, 02, 10));
        }
    }
}
