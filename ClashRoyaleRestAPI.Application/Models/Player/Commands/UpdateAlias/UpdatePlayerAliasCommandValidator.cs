using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias
{
    internal class UpdatePlayerAliasCommandValidator : AbstractValidator<UpdatePlayerAliasCommand>
    {
        public UpdatePlayerAliasCommandValidator()
        {
            RuleFor(x => x.Alias).NotNull().Length(3, 64);
        }
    }
}
