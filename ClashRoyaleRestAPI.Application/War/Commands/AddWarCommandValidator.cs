using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models.War;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.War.Commands
{
    internal class AddWarCommandValidator : AbstractValidator<AddModelCommand<WarModel, int>>
    {
        public AddWarCommandValidator()
        {
            RuleFor(x => x.Model.StartDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
