namespace Bacon.Factory
{
    public interface IBaconRepository
    {
        Task<List<string>> GetBaconFlavorsAsync();
    }
}