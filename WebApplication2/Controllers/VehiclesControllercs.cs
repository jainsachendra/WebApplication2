using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers.Resources;
using WebApplication2.Models;
using WebApplication2.Persistence;

namespace WebApplication2.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController:Controller
    {
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper,VegaDbContext context,IVehicleRepository repository,IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            Context = context;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IMapper Mapper { get; }
        public VegaDbContext Context { get; }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vehicle = Mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdated = DateTime.Now;
            repository.Add(vehicle);
            await unitOfWork.complete();
            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // var vehicle = await Context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            var vehicle = await repository.GetVehicle(id,includeReleted:false);
            if (vehicle == null)
                return NotFound();
            Mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
           // vehicle.LastUpdated = DateTime.Now;
         
            await unitOfWork.complete();
            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id,includeReleted:false);
            if (vehicle == null)
                return NotFound();
            repository.Remove(vehicle);
            //   Context.SaveChangesAsync();
            await unitOfWork.complete();
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeReleted: false);
            if (vehicle == null)
                return NotFound(id);
            var vehicleresource = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleresource);
        }
    }
}
