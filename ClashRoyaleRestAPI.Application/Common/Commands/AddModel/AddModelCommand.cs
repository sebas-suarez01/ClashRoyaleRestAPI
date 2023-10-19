using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Common.Commands.AddModel
{
    public record AddModelCommand<TModel, UId>(TModel Model) : ICommand<UId>
        where TModel : IEntity<UId>;
}
