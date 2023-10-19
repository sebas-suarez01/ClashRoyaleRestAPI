using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel
{
    public record DeleteModelCommand<TModel, UId>(TModel Model) : ICommand
        where TModel : IEntity<UId>;
}
