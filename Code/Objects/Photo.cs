namespace Code.Objects {

    public class ApiPhotosUrl {
        public string Raw {get; set;}
        public string Full {get; set;}
        public string Regular {get; set;}
        public string Small {get;set;}
        public string Thumb { get; set; }
    }

    public class ApiPhoto {
        public string Id { get; set;}
        public string Description { get; set; }
        public ApiPhotosUrl Urls { get; set;}
        public int Likes {get; set;}
        public int Downloads { get; set;}
        public int Views {get;set;}
    }

    public class Photo : BaseObj {
        public string Url { get; set;}
        public string Description {get;set;}
        public string Thumbnail { get; set; }

        public Photo(ApiPhoto apiObj) {
            Url = apiObj.Urls.Regular;
            Thumbnail = apiObj.Urls.Thumb;

            Description = apiObj.Description;
        }

        public Photo() {
            Url = "~/img/fox.jpg";
            Thumbnail = "~/img/fox.jpg";
            Description = "Default";
        }
    }
}