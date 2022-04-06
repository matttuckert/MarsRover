namespace MarsRover
{
    enum CardinalOrientation
    {
        N,
        E,
        S,
        W
    }

    enum Direction
    {
        L,
        R
    }

    // represents a position
    class Position
    {
        public int X {get; set;}
        public int Y {get; set;}

        public CardinalOrientation Orientation {get; set;}

        public Position(int x, int y, CardinalOrientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        // moves positions based on orientation
        public void Move()
        {
            switch(Orientation) {
                case CardinalOrientation.N:
                {
                    Y++;
                    break;
                }
                case CardinalOrientation.E:
                {
                    X++;
                    break;
                }
                case CardinalOrientation.S:
                {
                    Y--;
                    break;
                }
                case CardinalOrientation.W:
                {
                    X--;
                    break;
                }
                default: break;
            }
        }

        // changes orientation
        public void Rotate(Direction direction)
        {
            if (direction == Direction.R)
            {
                Orientation = (CardinalOrientation)((int)(Orientation + 1) % 4);
            }
            else if (direction == Direction.L)
            {
                Orientation = (CardinalOrientation)((int)(Orientation + 3) % 4);
            }
        }
    }
}