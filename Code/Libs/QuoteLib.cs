using Code.Objects;
using Code.Helpers;

using RestSharp;

namespace Code.Libs {
    public class QuoteLib : IObjLib<Quote> {
        private readonly IInnerApi _innerApi;

        public QuoteLib(IInnerApi innerApi) {
            _innerApi = innerApi;

        }

        public async Task<Quote> GetObj() {
            var request = new RestRequest("quotes");
            var response = await _innerApi.Fetch<List<ApiQuote>>(request);
            return new Quote(response.First());
        }
    }
}