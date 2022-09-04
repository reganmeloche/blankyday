using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {
    public class JokeLib : IObjLib<Joke> {
        private readonly IInnerApi _innerApi;

        public JokeLib(IInnerApi innerApi) {
            _innerApi = innerApi;

        }

        public async Task<Joke> GetObj() {
            var request = new RestRequest("jokes");
            request.AddQueryParameter("limit", 1);

            var response = await _innerApi.Fetch<List<ApiJoke>>(request);
            return new Joke(response.First());
        }
    }
}