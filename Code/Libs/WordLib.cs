using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {
    public class WordLib : IObjLib<Word> {
        private readonly IInnerApi _innerApi;
        private readonly IGetRandomWord _randomWordLib;
        private readonly int MAX_DEFS = 5;

        public WordLib(IInnerApi innerApi, IGetRandomWord randomWordLib) {
            _innerApi = innerApi;
            _randomWordLib = randomWordLib;
        }

        public async Task<Word> GetObj() {
            Word result = null;

            for (int i = 0; i < 4; i++) {
                string randomWord = await _randomWordLib.Get();
                var request = new RestRequest("dictionary");
                request.AddQueryParameter("word", randomWord);

                var response = await _innerApi.Fetch<ApiWord>(request);
                result = new Word(response);

                if (DefinitionsAreValid(result)) {
                    break;
                }
            }

            return result;

        }

        private bool DefinitionsAreValid(Word word) {
            if (word.Definitions.Count > 0 && word.Definitions.Count <= MAX_DEFS) {
                
                if (!String.IsNullOrWhiteSpace(word.Definitions[0])) {
                    return true;
                }
            }

            return false;
        }
    }
}