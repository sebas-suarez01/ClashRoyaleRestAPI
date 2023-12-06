using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddWar;

internal class AddWarCommandValidator : AbstractValidator<AddModelCommand<WarModel, int>>
{
    public AddWarCommandValidator()
    {
        RuleFor(x => x.Model.StartDate).NotNull().GreaterThanOrEqualTo(DateTime.UtcNow);
    }
}
