using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands
{
    internal class AddChallengeCommandHandler : AddModelCommandHandler<ChallengeModel, int>
    {
        public AddChallengeCommandHandler(IChallengeRepository repository) : base(repository)
        {
        }
    }
}
