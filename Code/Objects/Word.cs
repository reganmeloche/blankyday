using System.Text.RegularExpressions;

namespace Code.Objects {

    public class ApiWord {
        public string Word { get; set;}
        public string Definition { get; set; }
    }

    public class Word : BaseObj {

        public string WordText { get; set; }
        public List<string> Definitions { get; set; }

        public Word(ApiWord apiObj) {
            WordText = apiObj.Word;
            Regex regex = new Regex("\\d{1,2}\\."); 
            string[] substrings = regex.Split(apiObj.Definition);
            Definitions = new List<string>(substrings);
        }

        public Word() {
            WordText = "Grappa";
            Definitions = new List<string>() {
                "a brandy distilled from the fermented residue of grapes after they have been pressed in winemaking."
            };
        }
    }
}