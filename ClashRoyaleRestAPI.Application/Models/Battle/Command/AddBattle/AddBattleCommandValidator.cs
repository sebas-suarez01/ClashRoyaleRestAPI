using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandValidator : AbstractValidator<AddBattleCommand>
{
    public AddBattleCommandValidator()
    {
        RuleFor(x => x.WinnerId).NotEqual(t => t.LoserId);
        RuleFor(x => x.LoserId).NotEqual(t => t.WinnerId);

        RuleFor(x => x.AmountTrophies).InclusiveBetween(10, 40);
        RuleFor(x => x.DurationInSeconds).InclusiveBetween(1, 300);
    }
}
