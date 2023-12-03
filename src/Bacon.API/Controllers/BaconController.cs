using Bacon.Factory;
using Microsoft.AspNetCore.Mvc;

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
            return await baconRepository.GetBaconFlavorsAsync();
        }
    }
}