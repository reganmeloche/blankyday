using Code.Objects;
using Code.Helpers;

namespace Code.Libs {
    public class CalvinLib : IObjLib<Calvin> {
        private readonly IInnerCalvinApi _innerApi;

        public CalvinLib(IInnerCalvinApi innerApi) {
            _innerApi = innerApi;
        }

        public async Task<Calvin> GetObj() {
            var now = DateTime.Now;
            
            var month = now.Month; 
            string monthStr = month.ToString();
            if (month < 10) {
                monthStr = $"0{monthStr}";
            }

            var day = now.Day;
            string dayStr = day.ToString();
            if (day < 10) {
                dayStr = $"0{dayStr}";
            }

            var dateString = $"{now.Year}/{monthStr}/{dayStr}";
            var response = await _innerApi.Fetch(dateString);
            return response;
        }
    }
}