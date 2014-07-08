// ********************************
// <copyright file="ForLoopRefactoring.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;
using System.Collections.Generic;

/// <summary>
///     A class which demonstrates for-loop refactoring.
/// </summary>
internal class ForLoopRefactoring
{
    /// <summary>
    ///     Prints to the console the array elements until the current index satisfies
    ///     <paramref name="indexPredicate" /> and the element at this index is equal to
    ///     <paramref name="value" />.
    /// </summary>
    /// <param name="array">The array whose elements are to be printed.</param>
    /// <param name="indexPredicate">
    ///     The criteria that the current index should meet
    ///     in order to stop printing the array elements.
    /// </param>
    /// <param name="value">
    ///     The value that should be found in order to stop
    ///     printing the array elements.
    /// </param>
    private static void PrintElementsUntilIndexAndValueAreFound(IList<int> array, Predicate<int> indexPredicate,
        int value)
    {
        var arrayLength = array.Count;

        for (var index = 0; index < arrayLength; index++)
        {
            Console.WriteLine(array[index]);

            if (indexPredicate(index) && array[index] == value)
            {
                break;
            }
        }
    }

    /// <summary>
    ///     The entry point of the application.
    /// </summary>
    private static void Main()
    {
        const int value = 666;

        var array = new int[100];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        PrintElementsUntilIndexAndValueAreFound(array, i => i%10 == 0, value);
    }
}
