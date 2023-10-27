using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands
{
    internal class DeleteChallengeCommandHandler : DeleteModelCommandHandler<ChallengeModel, int>
    {
        public DeleteChallengeCommandHandler(IChallengeRepository repository) : base(repository)
        {
        }
    }
}
