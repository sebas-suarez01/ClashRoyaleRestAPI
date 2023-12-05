using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.UpdateChallenge
{
    internal class UpdateChallengeCommandValidator : AbstractValidator<UpdateModelCommand<ChallengeModel, int>>
    {
        public UpdateChallengeCommandValidator()
        {
            RuleFor(x => x.Model.AmountReward).NotNull().GreaterThan(0);
            RuleFor(x => x.Model.DurationInHours).NotNull().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().Length(3, 32);
            RuleFor(x => x.Model.Cost).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Model.Description).NotNull().NotEmpty();
            RuleFor(x => x.Model.StartDate).NotNull();
            RuleFor(x => x.Model.LossLimit).NotNull().GreaterThanOrEqualTo(3);
            RuleFor(x => x.Model.MinLevel).NotNull().InclusiveBetween(1, 15);
        }
    }
}
