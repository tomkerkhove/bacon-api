namespace Bacon.Factory
{
    public class BaconRepository : IBaconRepository
    {
        public Task<List<string>> GetBaconFlavorsAsync()
        {
            var flavors = new List<string>
            {
                "Honey Barbecue Flavored Bacon",
                "Infamous Black Pepper Bacon",
                "Italian Bacon",
                "Raspberry Chipotle",
                "Pumpkin Pie Spiced"
            };

            return Task.FromResult(flavors);
        }
    }
}
