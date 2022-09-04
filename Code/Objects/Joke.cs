using System.Linq;


namespace Code.Objects {

    public class ApiJoke {
        public string Joke { get; set;}
    }

    public class Joke: BaseObj {

        public string Text { get; set; }

        public Joke(ApiJoke apiObj) {
            Text = apiObj.Joke;
        }

        public Joke() {
            Text = "When is the best time to run a marathon? Lent - it's when you fast.";
        }
    }
}