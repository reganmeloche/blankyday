namespace Code.Objects {

    public class ApiExercise {
        public string Name { get; set;}
        public string Type { get; set;}
        public string Muscle { get; set;}
        public string Equipment { get; set;}
        public string Difficulty { get; set;}
        public string Instructions { get; set;}
    }

    public class Exercise : BaseObj {
        public string Name { get; set;}
        public string Type { get; set;}
        public string Muscle { get; set;}
        public string Equipment { get; set;}
        public string Difficulty { get; set;}
        public string Instructions { get; set;}

        public Exercise(ApiExercise apiObj) {
            Name = apiObj.Name;
            Type = apiObj.Type;
            Muscle = apiObj.Muscle;
            Equipment = apiObj.Equipment;
            Difficulty = apiObj.Difficulty;
            Instructions = apiObj.Instructions;
        }

        public Exercise() {
            Name = "ncline Hammer Curls";
            Type = "strength";
            Muscle = "biceps";
            Equipment = "dumbbell";
            Difficulty = "beginner";
            Instructions = "Seat yourself on an incline bench with a dumbbell in each hand. You should pressed firmly against he back with your feet together. Allow the dumbbells to hang straight down at your side, holding them with a neutral grip. This will be your starting position. Initiate the movement by flexing at the elbow, attempting to keep the upper arm stationary. Continue to the top of the movement and pause, then slowly return to the start position.";
        }
    }
}