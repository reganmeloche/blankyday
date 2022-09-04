using Code.Objects;
using Code.Helpers;

using RestSharp;

namespace Code.Libs {
    public class FactLib : IObjLib<Fact> {
        private readonly IInnerApi _innerApi;

        public FactLib(IInnerApi innerApi) {
            _innerApi = innerApi;
        }

        public async Task<Fact> GetObj() {
            var request = new RestRequest("facts");
            request.AddQueryParameter("limit", 1);

            var response = await _innerApi.Fetch<List<ApiFact>>(request);
            return new Fact(response.First());
        }
    }
}