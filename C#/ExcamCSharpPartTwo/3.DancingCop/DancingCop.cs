using System;

public enum Direction
{
    Up = 'U',
    Right = 'R',
    Down = 'D',
    Left = 'L'
}

class DancingCop
{
    private static char[,] danceFloor = new char[3, 3]
    {
        {'R', 'B', 'R'},
        {'B', 'G', 'B'},
        {'R', 'B', 'R'}
    };

    private static void Main()
    {
        var numDances = int.Parse(Console.ReadLine());
        var danceMoves = new string[numDances];

        for (int dance = 0; dance < numDances; dance++)
        {
            danceMoves[dance] = Console.ReadLine();
            int row = 1;
            int col = 1;
            var theHook = new Dancer(row, col);
            var result = DanceLikeTheHook(danceMoves, dance, theHook);

            PrintResult(result);
        }


    }

    private static char DanceLikeTheHook(string[] danceMoves, int dance, Dancer theHook)
    {
        for (int damceStep = 0; damceStep < danceMoves[dance].Length; damceStep++)
        {
            theHook.Move(danceMoves[dance][damceStep]);
        }
        char result = danceFloor[theHook.row, theHook.col];
        return result;
    }

    private static void PrintResult(char result)
    {
        if (result == 'B') Console.WriteLine("BLUE");
        else if (result == 'G') Console.WriteLine("GREEN");
        else if (result == 'R') Console.WriteLine("RED");
    }

    class Dancer
    {
        public Dancer(int r,int c)
        {
            row = r;
            col = c;
            MoveDirection = Direction.Up;
        }

        private int _row;
        private int _col;
        public int row
        {
            get { return _row; }
            set
            {
                if (value > 2)
                {
                    _row = 0;
                }
                else if (value < 0)
                {
                    _row = 2;
                }
                else
                {
                    _row = value;
                }
            }
        }
        public int col
        {
            get { return _col; }
            set
            {
                if (value > 2)
                {
                    _col = 0;
                }
                else if (value < 0)
                {
                    _col = 2;
                }
                else
                {
                    _col = value;
                }
            }
        }

        private Direction MoveDirection { get; set; }
        private void SwitchDirection(Direction d)
        {
            switch (MoveDirection)
            {
                case Direction.Up:
                {
                    MoveDirection = d == Direction.Left ? Direction.Left : Direction.Right;
                    break;
                }
                case Direction.Left:
                {
                    MoveDirection = d == Direction.Left ? Direction.Down : Direction.Up;
                    break;
                }
                case Direction.Down:
                {
                    MoveDirection = d == Direction.Left ? Direction.Right : Direction.Left;
                    break;
                }
                case Direction.Right:
                {
                    MoveDirection = d == Direction.Left ? Direction.Up : Direction.Down;
                    break;
                }
            }
        }
        public void Move(char commandMove)
        {
            switch (commandMove)
            {
                case 'L':SwitchDirection(Direction.Left);
                    break;
                case 'R':SwitchDirection(Direction.Right);
                    break;
                case 'W':Move();
                    break;
            }
        }
        private void Move()
        {
            switch (MoveDirection)
            {
                case Direction.Up:
                    row--;
                    break;
                case Direction.Down:
                    row++;
                    break;
                case Direction.Left:
                    col--;
                    break;
                case Direction.Right:
                    col++;
                    break;
            }
        }
    }

}

