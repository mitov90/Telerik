using System;
using System.Collections.Generic;
using System.Linq;

class QuickSortTemplate
{
    static Random gen = new Random();
    static void Main()
    {
        List<int> myArr;

        InputValues(out myArr);
        MyQuickSort(myArr, 0, myArr.Count - 1);

        foreach ( var item in myArr )
        {
            Console.WriteLine(item);
        }
    }

    private static void MyQuickSort(List<int> myArr, int left, int right)
    {
        int i = left;
        int j = right;
        int pivot = i + gen.Next() % ( j - i );

        while ( i <= j )
        {
            while ( myArr[i].CompareTo(myArr[pivot]) < 0 )
            {
                i++;
            }
            while ( myArr[j].CompareTo(myArr[pivot]) > 0 )
            {
                j--;
            }
            if ( i <= j )
            {
                //swap
                var temp = myArr[i];
                myArr[i] = myArr[j];
                myArr[j] = temp;
                i++;
                j--;
            }
        }
        if ( j > left )
            MyQuickSort(myArr, left, j);
        if ( right > i )
            MyQuickSort(myArr, i, right);

    }

    private static void InputValues(out List<int> myList)
    {
        byte arrSize;
        do
        {
            Console.Write("Enter array size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out arrSize) || arrSize < 1 );
        myList = new List<int>(arrSize);
        for ( int i = 0; i < arrSize; i++ )
        {
            int tempNum;
            do
            {
                Console.Write("Enter {0} element:", i + 1);
            }
            while ( !int.TryParse(Console.ReadLine(), out tempNum) );
            myList.Add(tempNum);
        }
    }



}
