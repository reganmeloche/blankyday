using Code.Objects;
using RestSharp;

using HtmlAgilityPack;

using Microsoft.Extensions.Options;

namespace Code.Helpers {

    public class CalvinApiOptions {
        public string RootUrl { get; set; }
    }

    public interface IInnerCalvinApi {
        Task<Calvin> Fetch(string req); 
    }

    public class CalvinApi : IInnerCalvinApi {
        readonly string _rootUrl;
        readonly HtmlWeb _web;

        public CalvinApi(IOptions<CalvinApiOptions> optionsAccessor) {
            _rootUrl = optionsAccessor.Value.RootUrl;
            _web = new HtmlWeb();
        }

        public async Task<Calvin> Fetch(string req) {
            // TODO: Add more robust error-handling
            var imgUrl = "null";
            try {
                var doc = _web.Load($"{_rootUrl}/{req}");
                var pic = doc.DocumentNode.SelectSingleNode("//picture[contains(@class, 'item-comic-image')]");
                var img = pic.ChildNodes["img"];
                imgUrl = img.Attributes["src"].Value;

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
            return new Calvin {
                ImgUrl = imgUrl,
                Description = req
            };
        }

    }
}