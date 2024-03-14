using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;

public record AddModelCommand<TModel, UId>(TModel Model) : ICommand<UId>
    where TModel : IEntity<UId>;
