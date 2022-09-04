using Code.Objects;
using Code.Helpers;
using RestSharp;

namespace Code.Libs {
    public class RiddleLib : IObjLib<Riddle> {
        private readonly IInnerApi _innerApi;

        public RiddleLib(IInnerApi innerApi) {
            _innerApi = innerApi;
        }

        public async Task<Riddle> GetObj() {
            var request = new RestRequest("riddles");
            var response = await _innerApi.Fetch<List<ApiRiddle>>(request);
            return new Riddle(response.First());
        }
    }
}