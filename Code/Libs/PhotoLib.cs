using Code.Objects;
using Code.Helpers;

using Microsoft.Extensions.Options;

using RestSharp;

namespace Code.Libs {
    public class PhotoLib : IObjLib<Photo> {
        private readonly IInnerPhotoApi _innerApi;
        private readonly IChooseUnsplashPhoto _photoChooser;
        private readonly string _topics;

        public PhotoLib(
            IInnerPhotoApi innerApi,
            IChooseUnsplashPhoto photoChooser

        ) {
            _innerApi = innerApi;
            _photoChooser = photoChooser;
            _topics = "nature,architecture";
        }

        public async Task<Photo> GetObj() {
            var request = new RestRequest("photos/random");
            request.AddQueryParameter("count", 10);
            request.AddQueryParameter("topics", _topics);

            var response = await _innerApi.Fetch<List<ApiPhoto>>(request);

            var photo = _photoChooser.Choose(response);

            return new Photo(response.First());
        }
    }
}