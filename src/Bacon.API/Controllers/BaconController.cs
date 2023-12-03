using Microsoft.AspNetCore.Mvc;

namespace Bacon.API.Controllers
{
    [ApiController]
    [Route("api/v1/bacon")]
    public class BaconController : ControllerBase
    {
        [HttpGet(Name = "GetBacon")]
        public IEnumerable<string> Get()
        {
            return new List<string>
            {
                "Honey Barbecue Flavored Bacon",
                "Infamous Black Pepper Bacon",
                "Italian Bacon",
                "Raspberry Chipotle",
                "Pumpkin Pie Spiced"
            };
        }
    }
}