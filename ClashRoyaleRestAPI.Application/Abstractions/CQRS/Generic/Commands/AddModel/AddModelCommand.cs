using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;

public record AddModelCommand<TModel, UId>(TModel Model) : ICommand<UId>
    where TModel : IEntity<UId>;
