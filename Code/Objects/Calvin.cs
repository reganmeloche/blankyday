using System.Linq;

using System.Text.RegularExpressions;

namespace Code.Objects {
    public class Calvin : BaseObj {
        public string Description {get; set; }
        public string ImgUrl { get; set;}

        public Calvin() {
            Description = "Lunboks!";
            ImgUrl = "~/img/lunboks.gif";
        }
    }
}