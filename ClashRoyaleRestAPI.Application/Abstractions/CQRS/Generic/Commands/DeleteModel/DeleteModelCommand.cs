using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;

public record DeleteModelCommand<TModel, UId>(UId Id) : ICommand
    where TModel : IEntity<UId>;
