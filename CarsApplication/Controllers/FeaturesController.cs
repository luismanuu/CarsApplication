using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarsApplication.Controllers.Resources;
using CarsApplication.Models;
using CarsApplication.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}