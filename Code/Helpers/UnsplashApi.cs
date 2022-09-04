using Code.Objects;
using RestSharp;

using Microsoft.Extensions.Options;

namespace Code.Helpers {

    public class UnsplashApiOptions {
        public string RootApi { get; set; }
        public string AccessKey { get; set; }
    }

    public interface IInnerPhotoApi : IInnerApi {}

    public class UnsplashApi : IInnerPhotoApi {

        readonly RestClient _client;
        readonly string _accessKey;

        public UnsplashApi(IOptions<UnsplashApiOptions> optionsAccessor) {
            _client = new RestClient(optionsAccessor.Value.RootApi);
            _client.UseJson();
            _accessKey = optionsAccessor.Value.AccessKey;
        }

        public async Task<T> Fetch<T>(RestRequest request) {
            request.AddHeader("Accept-Version", "v1");
            request.AddQueryParameter("client_id", _accessKey);

            var response = await _client.GetAsync<T>(request);
            return response;
        }

    }
}