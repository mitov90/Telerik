using System;

public enum Direction
{
    Up = 'U',
    Down = 'D',
    Right = 'R',
    Left = 'L'
};


class Tron3D
{
    private static bool[,] field;

    static void Main()
    {
        #region init
        var dimenssions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var commandsRed = Console.ReadLine();
        var commandsBlue = Console.ReadLine();
        
        int x = int.Parse(dimenssions[0]);
        int y = int.Parse(dimenssions[1]);
        int z = int.Parse(dimenssions[2]);
        field = new bool[x + 1, ( z + y ) * 2];
        int startX = (x + 1)/2;
        int redStartY = z + y/2;
        field[startX, redStartY] = true;
        field[startX, 2*z + y + y/2] = true;
        Player redPlayer = new Player(startX,redStartY , Direction.Right);
        Player bluePlayer = new Player(startX, 2 * z + y + y / 2, Direction.Left);
        #endregion

        int step = 0;
        while ( true )
        {
            if ( redPlayer.Col == bluePlayer.Col && redPlayer.Row == bluePlayer.Row )
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(redPlayer.DistanceTo(startX,redStartY));
                break;

            }
            if ( redPlayer.Dead || bluePlayer.Dead )
            {
                string winner = string.Empty;
                if ( redPlayer.Dead == bluePlayer.Dead )
                {
                    winner = "DRAW";
                }
                else
                {
                    winner = redPlayer.Dead ? "BLUE" : "RED";
                }
                Console.WriteLine(winner);
                Console.WriteLine(redPlayer.DistanceTo(startX,redStartY));
                break;
            }

            if ( commandsRed.Length > step )
            {
                redPlayer.ChangeDirection(commandsRed[step]);
                if ( commandsRed[step] == 'M' )
                    redPlayer.Move();

            }
            if ( commandsBlue.Length > step )
            {
                bluePlayer.ChangeDirection(commandsBlue[step]);
                if ( commandsBlue[step] == 'M' )
                    bluePlayer.Move();
            }


            step++;
        }
    }

    class Player
    {
        public Player(int row, int col, Direction startDirection)
        {
            Dead = false;
            this.Row = row;
            this.Col = col;
            this.CurrentDirection = startDirection;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        private Direction CurrentDirection { get; set; }

        public bool Dead { get; set; }

        public void ChangeDirection(char command)
        {
            switch ( CurrentDirection )
            {
                case Direction.Down:
                    if ( command == 'R' )
                    {
                        CurrentDirection = Direction.Left;
                    }
                    if ( command == 'L' )
                    {
                        CurrentDirection = Direction.Right;
                    }
                    break;
                case Direction.Left:
                    if ( command == 'R' )
                    {
                        CurrentDirection = Direction.Up;
                    }
                    if ( command == 'L' )
                    {
                        CurrentDirection = Direction.Down;
                    }
                    break;
                case Direction.Right:
                    if ( command == 'R' )
                    {
                        CurrentDirection = Direction.Down;
                    }
                    if ( command == 'L' )
                    {
                        CurrentDirection = Direction.Up;
                    }
                    break;
                case Direction.Up:
                    if ( command == 'R' )
                    {
                        CurrentDirection = Direction.Right;
                    }
                    if ( command == 'L' )
                    {
                        CurrentDirection = Direction.Left;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }

        public int DistanceTo(int row, int col)
        {
            int colsDistance = Math.Abs(col - this.Col );
            if ( colsDistance > field.GetLength(1) / 2 )
                colsDistance = field.GetLength(1) - 1 - colsDistance;
            return Math.Abs(row - this.Row) + colsDistance;
        }

        public bool Move()
        {

            switch ( CurrentDirection )
            {
                case Direction.Up:
                    Row--;
                    break;
                case Direction.Down:
                    Row++;
                    break;
                case Direction.Left:
                    Col--;
                    break;
                case Direction.Right:
                    Col++;
                    break;
            }

            //Check boundaries
            if ( Col < 0 )
            {
                Col = field.GetLength(1) - 1;
            }
            else if ( Col > field.GetLength(1) - 1 )
            {
                Col = 0;
            }
            else if ( Row < 0 )
            {
                Row = 0;
                Dead = true;
                return false;
            }
            else if ( Row > field.GetLength(0) - 1 )
            {
                Row = field.GetLength(0) - 1;
                Dead = true;
                return false;
            }

            //Check is it visited
            if ( field[Row, Col] == true )
            {
                Dead = true;
                return false;
            }
            //Visit
            field[Row, Col] = true;
            return true;
        }

    }

}
