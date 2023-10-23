using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Auth.User.Queries.GetAllUser
{
    public record GetAllUserQuery() : IQuery<IEnumerable<UserModel>>;
}
