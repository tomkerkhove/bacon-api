using Bacon.Factory;
using Grpc.Core;
using static Bacon.gRPC.Service.Bacon;

namespace Bacon.gRPC.Service.Services
{
    public class BaconService : BaconBase
    {
        readonly IBaconRepository baconRepository;

        public BaconService(IBaconRepository baconRepository)
        {
            this.baconRepository = baconRepository;
        }

        public override async Task<BaconResponse> GetBacon(BaconRequest request, ServerCallContext serverCallContext)
        {
            var flavors = await baconRepository.GetBaconFlavorsAsync();

            var response = new BaconResponse();
            response.Flavors.AddRange(flavors);

            return response;
        }
    }
}
