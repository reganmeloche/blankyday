using Code.Objects;
using Code.Helpers;
using RestSharp;

namespace Code.Libs {
    public class HistoricalEventLib : IObjLib<HistoricalEvent> {
        private readonly IInnerApi _innerApi;

        public HistoricalEventLib(IInnerApi innerApi) {
            _innerApi = innerApi;

        }

        public async Task<HistoricalEvent> GetObj() {
            var request = new RestRequest("historicalevents");
            request.AddQueryParameter("month", DateTime.Now.Month);
            request.AddQueryParameter("day", DateTime.Now.Day);
            var response = await _innerApi.Fetch<List<ApiHistoricalEvent>>(request);

            var rnd = new Random();
            var selectedInd = rnd.Next(response.Count());
            var selectedResponse = response[selectedInd];
            return new HistoricalEvent(selectedResponse);
        }
    }
}