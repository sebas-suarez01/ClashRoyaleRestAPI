using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;

public record DeleteModelCommand<TModel, UId>(UId Id) : ICommand
    where TModel : IEntity<UId>;
