using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer;

internal class AddPlayerCommandValidator : AbstractValidator<AddModelCommand<PlayerModel, PlayerId>>
{
    public AddPlayerCommandValidator()
    {
        RuleFor(x => x.Model.Alias).NotNull().Length(3, 64);
        RuleFor(x => x.Model.Elo).NotNull().InclusiveBetween(0, 9000);
        RuleFor(x => x.Model.Level).NotNull().InclusiveBetween(1, 15);
    }
}
