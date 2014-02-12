using System;

class SpecialValue
{
    private static bool[][] visited;
    private static void GetInput(int rows, int[][] field)
    {
        visited= new bool[rows][];
        for (int i = 0; i < rows; i++)
        {
            var inputRow = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries);
            field[i] = new int[inputRow.Length];
            visited[i] = new bool[inputRow.Length];
            for (int curNumber = 0; curNumber < inputRow.Length; curNumber++)
            {
                field[i][curNumber] = int.Parse(inputRow[curNumber]);
            }
        }
    }

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        var field = new int[rows][];
        GetInput(rows, field);

        int maxSpecialValue = 0;
        for (int digitFromFirstRow = 0; digitFromFirstRow < field[0].GetLength(0); digitFromFirstRow++) //StartingPointFromFirstROw
        {
            //clear path
            int row = 0;
            int col = digitFromFirstRow;
            int specialValue = 0;

            while(true)
            {
                if (visited[row][col])
                {
                    break;
                }
                else
                {
                    visited[row][col] = true;
                }
                specialValue++;
                int curDigit = field[row][col];

                if (curDigit >= 0)
                {
                    col = field[row][col];

                    if (row == field.GetLength(0) - 1)
                    {
                        row = 0;
                    }
                    else
                    {
                        row++;
                    }
                }
                else
                {
                    specialValue += Math.Abs(field[row][col]);
                    break;
                }

            }

            if (specialValue > maxSpecialValue)
            {
                maxSpecialValue = specialValue;
            }
        }
        Console.WriteLine(maxSpecialValue);

    }

    private static bool IsVisited(int? nullable)
    {
        return false;
        //throw new NotImplementedException();
    }

    
}
