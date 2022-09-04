using Code.Objects;
using RestSharp;
using System.Linq;

using Microsoft.Extensions.Options;

namespace Code.Helpers {

    public interface IChooseUnsplashPhoto {
        public ApiPhoto Choose(List<ApiPhoto> photos);
    }

    public class PhotoChooser : IChooseUnsplashPhoto {

        public ApiPhoto Choose(List<ApiPhoto> photos) {
            var sorted = photos.OrderBy(x => x.Likes * (x.Downloads/100) * (x.Views/10000));
            return sorted.First();
        }

    }
}