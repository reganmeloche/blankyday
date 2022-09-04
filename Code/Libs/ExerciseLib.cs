using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {


    public class ExerciseLib : IObjLib<Exercise> {
        private readonly IInnerApi _innerApi;

        public ExerciseLib(IInnerApi innerApi) {
            _innerApi = innerApi;
        }

        public async Task<Exercise> GetObj() {
            var rnd = new Random();
            int index = rnd.Next(_exerciseTypes.Count());
            string exerciseType = _exerciseTypes[index];

            var request = new RestRequest("exercises");
            request.AddQueryParameter("type", exerciseType);
            var response = await _innerApi.Fetch<List<ApiExercise>>(request);

            var selectedInd = rnd.Next(response.Count());
            var selectedResponse = response[selectedInd];
            return new Exercise(selectedResponse);
        }

        private readonly string[] _exerciseTypes = new string[] {"cardio", "olympic_weightlifting", "plyometrics", "powerlifting", "strength", "stretching", "strongman" };

    }
}