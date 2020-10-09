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
    public class MakesController:Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public MakesController( VegaDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("/api/makes")]
        public async Task< IEnumerable<MakeResource>> Get()
        {
            var makes= await context.makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}
