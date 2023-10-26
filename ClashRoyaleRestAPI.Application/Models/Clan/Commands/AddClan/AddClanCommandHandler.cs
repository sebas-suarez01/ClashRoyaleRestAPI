using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (IdNotFoundException)
            {
                return Result.Failure<int>(ErrorTypes.Models.IdNotFound);
            }

            return request.Clan.Id;
        }
    }
}
