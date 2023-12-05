using Bacon.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bacon.API.Controllers
{
    [ApiController]
    [Route("api/v1/bacon")]
    public class BaconController : ControllerBase
    {
        readonly IBaconRepository baconRepository;
        
        public BaconController(IBaconRepository baconRepository)
        {
            this.baconRepository = baconRepository;
        }

        [HttpGet(Name = "GetBacon")]
        public async Task<List<string>> Get()
        {
            if (Environment.GetEnvironmentVariable("CHAOS_ENABLED") == Boolean.TrueString
                || Request.Headers.ContainsKey("X-Chaos"))
            {
                throw new ApplicationException("Woops, things are going wrong");
            }
            
            return await baconRepository.GetBaconFlavorsAsync();
        }
    }
}