using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan
{
    public class AddClanCommandHandler : ICommandHandler<AddClanCommand, int>
    {
        private readonly IClanRepository _repository;

        public AddClanCommandHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(AddClanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Add(request.PlayerId, request.Clan);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure<int>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return request.Clan.Id;
        }
    }
}
