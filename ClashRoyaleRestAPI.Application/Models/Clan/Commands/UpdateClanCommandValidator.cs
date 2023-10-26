using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands
{
    internal class UpdateClanCommandValidator : AbstractValidator<UpdateModelCommand<ClanModel, int>>
    {
        public UpdateClanCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().NotNull().Length(3, 64);
            RuleFor(x => x.Model.Region).NotEmpty().NotNull().Length(3, 32);
            RuleFor(x => x.Model.TypeOpen).NotEmpty().NotNull();
            RuleFor(x => x.Model.MinTrophies).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
