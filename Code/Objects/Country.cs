namespace Code.Objects {

    public class ApiCountry {
        public string Name { get; set; }
        public string Capital { get; set; }
        public float Population { get; set; }
        public float Pop_Density { get; set; }
    }

    public class Country : BaseObj {

        public string Name { get; set; }
        public string Capital { get; set; }
        public float Population { get; set; }
        public float PopulationDensity { get; set; }

        public Country(ApiCountry apiObj) {
            Name = apiObj.Name;
            Capital = apiObj.Capital;
            Population = apiObj.Population * 1000;
            PopulationDensity = apiObj.Pop_Density;
        }

        public Country() {
            Name = "Canada";
            Capital = "Ottawa";
            Population = 37742;
            PopulationDensity = 4.2f;
        }
    }
}