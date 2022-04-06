namespace MarsRover
{
    // entry point class
    class Entry
    {
        // entry point method
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("Invalid Arguments. This Program accepts one argument");
                return;
            }

            string filePath = args[0];

            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Invalid Arguments. Unable to find file");
                return;
            }
            if (lines.Length == 0)
            {
                Console.WriteLine("Invalid File Format. The file must have at least one line");
                return;
            }
            if (lines.Length % 2 == 0)
            {
                Console.WriteLine("Invalid File Format. The file must have an odd number of lines");
                return;
            }
            string[] plateauLine = lines[0].Split(" ");
            if (plateauLine.Length != 2) {
                Console.WriteLine("Invalid File Format. The dimensions of the plateau are invalid");
                return;
            }
            Plateau plateau;
            if (Int32.TryParse(plateauLine[0], out int x) && Int32.TryParse(plateauLine[1], out int y))
            {
                plateau = new Plateau(x, y);
            }
            else
            {
                Console.WriteLine("Invalid File Format. Dimensions must be numbers.");
                return;
            }
            for (int i = 1; i < lines.Length; i+=2)
            {
                string[] roverStartingLine = lines[i].Split(" ");
                string roverPathLine = lines[i + 1]; // don't need an index range check here because of the odd number of lines check earlier
                Rover? rover = createRover(roverStartingLine,roverPathLine);
                if (rover == null)
                {
                    Console.WriteLine(String.Format("Invalid File Format. Invalid Rover format at line {0}", i));
                    return;
                }
                plateau.Rovers.Add(rover);
            }
            executeRoverPaths(plateau);
        }

        // helper method to create a Rover object from string input
        private static Rover? createRover(string[] startingLine, string pathLine)
        {
            if (startingLine.Length != 3) {
                return null;
            }
            int x;
            int y;
            CardinalOrientation orientation;
            if (Int32.TryParse(startingLine[0], out x) && Int32.TryParse(startingLine[1], out y) && Enum.TryParse(startingLine[2], out orientation))
            {
                // do nothing
            }
            else
            {
                return null;
            }
            Rover rover = new Rover(new Position(x, y, orientation));
            foreach(char c in pathLine)
            {
                Action action;
                if (Enum.TryParse(c.ToString(), out action))
                {
                    // do nothing
                }
                else
                {
                    return null;
                }
                rover.Path.Add(action);
            }
            return rover;
        }

        // helper method to produce output from executing rover paths
        private static void executeRoverPaths(Plateau plateau)
        {
            foreach(Rover rover in plateau.Rovers)
            {
                rover.executePath();
                Position? position = rover.CurrentPosition;
                if (position == null)
                {
                    Console.WriteLine("Rover fell off the plateau!");
                }
                else{
                    Console.WriteLine(position.X.ToString() + " " + position.Y.ToString() + " " + position.Orientation.ToString());
                }
            }
        }
    }
}