using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel
{
    public record UpdateModelCommand<TModel, UId>(TModel Model) : ICommand
        where TModel : IEntity<UId>;
}
