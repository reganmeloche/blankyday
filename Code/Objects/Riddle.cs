
namespace Code.Objects {

    public class ApiRiddle {
        public string Title { get; set;}
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class Riddle : BaseObj {

        public string Title { get; set;}
        public string Question { get; set; }
        public string Answer { get; set; }

        public Riddle(ApiRiddle apiObj) {
            Title = apiObj.Title;
            Question = apiObj.Question;
            Answer = apiObj.Answer;
        }

        public Riddle() {
            Title = "Shorter";
            Question = "What gets shorter when you add two letters to it?";
            Answer = "The word Short";
        }
    }
}