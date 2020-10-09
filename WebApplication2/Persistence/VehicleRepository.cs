using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Persistence
{
    public class VehicleRepository: IVehicleRepository
    {
        public VehicleRepository(VegaDbContext context){
          
            Context = context;
        }

        public VegaDbContext Context { get; }

        public async Task<Vehicle> GetVehicle(int id,bool includeReleted=true)
        {
            if (!includeReleted)
                return await Context.Vehicles.FindAsync(id);
            return  await Context.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public async Task<Vehicle> GetVehiclewithmake(int id)
        {
            
            return await Context.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public void Add(Vehicle vehicle)
        {
            Context.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            Context.Remove(vehicle);
        }
    }
}
