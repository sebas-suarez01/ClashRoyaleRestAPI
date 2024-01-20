using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddWar;

internal class AddWarCommandValidator : AbstractValidator<AddModelCommand<WarModel, WarId>>
{
    public AddWarCommandValidator()
    {
        RuleFor(x => x.Model.StartDate).NotNull().GreaterThanOrEqualTo(DateTime.UtcNow);
    }
}
