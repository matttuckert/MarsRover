namespace MarsRover
{

    // represents the plateau on Mars
    class Plateau
    {
        public static int X {get; set;}
        public static int Y {get; set;}
        public List<Rover> Rovers{get; set;} = new List<Rover>();

        public Plateau(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}