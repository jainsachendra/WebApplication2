using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers.Resources;
using WebApplication2.Migrations;
using WebApplication2.Persistence;

namespace WebApplication2.Controllers
{
    public class FeatureController: Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeatureController(VegaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("/api/features")]
        [Authorize]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await context.Feature.ToListAsync();

            //return mapper.Map<List<Feature>, List<FeatureResource>>(features);
            var list = Mapper.Map<List<KeyValuePairResource>>(features);
            return list;
        }
    }
}
