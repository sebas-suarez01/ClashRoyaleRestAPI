using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Challenge;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands
{
    public class AddChallengeCommandHandler : AddModelCommandHandler<ChallengeModel, int>
    {
        public AddChallengeCommandHandler(IChallengeRepository repository) : base(repository)
        {
        }
    }
}
