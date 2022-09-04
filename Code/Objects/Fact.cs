using System.Linq;

using System.Text.RegularExpressions;

namespace Code.Objects {

    public class ApiFact {
        public string Fact { get; set;}
    }

    public class Fact : BaseObj {

        public string Text { get; set; }

        public Fact(ApiFact apiObj) {
            Text = apiObj.Fact;
        }

        public Fact() {
            Text = "Gin and tonic was invented to make tonic more drinkable. British troops stationed in India drank tonic water for its quinine content to prevent malaria. The tonic water at the time was extremely bitter, so they added gin to make it more enjoyable";
        }
    }
}