namespace Code.Objects {

    public class ApiHistoricalEvent {
        public string Event { get; set;}
        public float Year { get; set; }
    }

    public class HistoricalEvent : BaseObj {

        public string Event { get; set; }
        public float Year { get; set; }

        public HistoricalEvent(ApiHistoricalEvent apiObj) {
            Event = apiObj.Event;
            Year = apiObj.Year;
        }

        public HistoricalEvent() {
            Event = "Something happened";
            Year = 2022;
        }
    }
}