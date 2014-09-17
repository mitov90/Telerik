using System;
using System.Linq;
using System.Text;

internal class Indices
{
    private static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());
        var arr =Console.ReadLine()
                   .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
        
        var visited = new bool[arraySize];
        var result = new StringBuilder();
        var curIndex = 0;

        while (true)
        {

            if (curIndex > arraySize || curIndex < 0)
            {
                break;
            }
            else if (visited[curIndex] == true)
            {
                result.Replace(string.Format(" {0} ",curIndex), string.Format("({0} ", curIndex));
                result.Insert(result.Length-1,')');
                break;
            }

            result.AppendFormat("{0} ", curIndex);
            visited[curIndex] = true;
            curIndex = arr[curIndex];
        }

        Console.WriteLine(result.ToString().Trim());
    }
}
