using RestSharp;

using Microsoft.Extensions.Options;

namespace Code.Helpers {

    public class InnerApiOptions {
        public string RootApi { get; set; }
        public string ApiKey { get; set; }
    }

    public interface IInnerApi {
        public Task<T> Fetch<T>(RestRequest request);
    }

    public class InnerApi : IInnerApi {

        readonly RestClient _client;
        readonly string _apiKey;

        public InnerApi(IOptions<InnerApiOptions> optionsAccessor) {
            _client = new RestClient(optionsAccessor.Value.RootApi);
            _client.UseJson();
            _apiKey = optionsAccessor.Value.ApiKey;
        }

        public async Task<T> Fetch<T>(RestRequest request) {
            request.AddHeader("X-Api-Key", _apiKey);

            var response = await _client.GetAsync<T>(request);
            return response;
        }

    }
}