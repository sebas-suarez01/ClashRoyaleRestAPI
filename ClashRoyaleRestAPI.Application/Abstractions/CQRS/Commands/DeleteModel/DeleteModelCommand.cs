using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;

public record DeleteModelCommand<TModel, UId>(UId Id) : ICommand
    where TModel : IEntity<UId>;
