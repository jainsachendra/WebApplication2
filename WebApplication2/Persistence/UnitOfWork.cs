using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(VegaDbContext context)
        {
            Context = context;
        }

        public VegaDbContext Context { get; }

        public async Task complete()
        {
            await Context.SaveChangesAsync();
        }
    }
}
