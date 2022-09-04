using System.Linq;

using System.Text.RegularExpressions;

namespace Code.Objects {

    public class ApiQuote {
        public string Quote { get; set;}
        public string Author { get; set; }
        public string Category { get; set; }
    }

    public class Quote : BaseObj {

        public string Text { get; set;}
        public string Author { get; set; }
        public string Category { get; set; }

        public Quote(ApiQuote apiObj) {
            Text = apiObj.Quote;
            Author = apiObj.Author;
            Category = apiObj.Category;
        }

        public Quote() {
            Text = "Keep cool. Do not freeze.";
            Author = "Back of a Mayo Jar";
            Category = "Motivation";
        }
    }
}