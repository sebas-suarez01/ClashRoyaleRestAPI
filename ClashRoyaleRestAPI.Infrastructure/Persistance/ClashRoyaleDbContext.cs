using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance
{
    public class ClashRoyaleDbContext : IdentityDbContext
    {
        public ClashRoyaleDbContext(DbContextOptions<ClashRoyaleDbContext> options): base(options) { }


    }
}
