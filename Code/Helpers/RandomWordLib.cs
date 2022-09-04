using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {

    public class ApiRandomWord {
        public string Word { get; set; }
    }

    public interface IGetRandomWord {
        Task<string> Get();
    }

    public class RandomWordLib : IGetRandomWord {
        private readonly IInnerApi _innerApi;

        public RandomWordLib(IInnerApi innerApi) {
            _innerApi = innerApi;
        }

        public async Task<string> Get() {
            var request = new RestRequest("randomword");
            var response = await _innerApi.Fetch<ApiRandomWord>(request);
            return response.Word;
        }
    }
}