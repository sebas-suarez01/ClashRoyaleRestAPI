using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Challenge;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands
{
    internal class UpdateChallengeCommandHandler : UpdateModelCommandHandler<ChallengeModel, int>
    {
        public UpdateChallengeCommandHandler(IChallengeRepository repository) : base(repository)
        {
        }
    }
}
