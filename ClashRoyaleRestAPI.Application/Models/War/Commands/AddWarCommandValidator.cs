﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands
{
    internal class AddWarCommandValidator : AbstractValidator<AddModelCommand<WarModel, int>>
    {
        public AddWarCommandValidator()
        {
            RuleFor(x => x.Model.StartDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
