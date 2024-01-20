using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdateClan;

internal class UpdateClanCommandValidator : AbstractValidator<UpdateModelCommand<ClanModel, ClanId>>
{
    public UpdateClanCommandValidator()
    {
        RuleFor(x => x.Model.Name).NotNull().Length(3, 64);
        RuleFor(x => x.Model.Region).NotNull().Length(3, 32);
        RuleFor(x => x.Model.TypeOpen).NotNull();
        RuleFor(x => x.Model.MinTrophies).NotNull().GreaterThanOrEqualTo(0);
    }
}
