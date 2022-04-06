namespace MarsRover
{
    enum Action
    {
        L,
        R,
        M,
    }

    // represents a Rover object
    class Rover
    {
        public List<Action> Path {get; set;} = new List<Action>();

        public Position? CurrentPosition {get; set;}

        public Rover(Position position)
        {
            CurrentPosition = position;
            checkPosition();
        }

        // executes a path to get to a new position
        // sets position to null if the rover falls off the plateau
        public void executePath()
        {
            foreach(Action action in Path) {
                if (CurrentPosition == null) {
                    return;
                }
                switch(action)
                {
                    case Action.L:
                    {
                        CurrentPosition.Rotate(Direction.L);
                        break;
                    }
                    case Action.R:
                    {
                        CurrentPosition.Rotate(Direction.R);
                        break;
                    }
                    case Action.M:
                    {
                        CurrentPosition.Move();
                        break;
                    }
                    default: break;
                }
                checkPosition();
            }
        }

        // checks if the psotion is on the plateau
        private void checkPosition()
        {
            if (CurrentPosition != null && (CurrentPosition.X > Plateau.X || CurrentPosition.Y > Plateau.Y || CurrentPosition.X < 0 || CurrentPosition.Y < 0))
            {
                CurrentPosition = null;
            }
        }
    }
}