using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {
    public class WordLib : IObjLib<Word> {
        private readonly IInnerApi _innerApi;
        private readonly IGetRandomWord _randomWordLib;

        public WordLib(IInnerApi innerApi, IGetRandomWord randomWordLib) {
            _innerApi = innerApi;
            _randomWordLib = randomWordLib;
        }

        public async Task<Word> GetObj() {
            string word = await _randomWordLib.Get();
            var request = new RestRequest("dictionary");
            request.AddQueryParameter("word", word);

            var response = await _innerApi.Fetch<ApiWord>(request);
            return new Word(response);
        }
    }
}