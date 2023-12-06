using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandValidator : AbstractValidator<AddClanCommand>
{
    public AddClanCommandValidator()
    {
        RuleFor(x => x.Clan.Name).NotNull().Length(3, 64);
        RuleFor(x => x.Clan.Region).NotNull().Length(3, 32);
        RuleFor(x => x.Clan.MinTrophies).NotNull().GreaterThanOrEqualTo(0);

    }
}
