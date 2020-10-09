using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Persistence
{
    public interface IUnitOfWork
    {
        Task complete();
    }
}
