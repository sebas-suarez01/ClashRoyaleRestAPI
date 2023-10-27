using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Domain.Errors;

namespace ClashRoyaleRestAPI.Application.Auth.User.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserResponse userResponse;

            try
            {
                userResponse = await _repository.GetUserByIdAsync(request.Id);
            }
            catch (IdNotFoundException<string> e)
            {
                return Result.Failure<UserResponse>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return userResponse;
        }
    }
}
