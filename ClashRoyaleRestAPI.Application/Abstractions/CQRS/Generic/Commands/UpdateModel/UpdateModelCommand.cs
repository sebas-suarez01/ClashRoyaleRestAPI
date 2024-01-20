using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;

public record UpdateModelCommand<TModel, UId>(TModel Model) : ICommand
    where TModel : IEntity<UId>;
