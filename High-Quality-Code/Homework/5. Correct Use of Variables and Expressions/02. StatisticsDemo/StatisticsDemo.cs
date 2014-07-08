// ********************************
// <copyright file="StatisticsDemo.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using Statistics;

namespace StatisticsDemo
{
    /// <summary>
    /// A class which demonstrates the use of <see cref="Statistics.StatisticalUtils"/>.
    /// </summary>
    internal class StatisticsDemo
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        private static void Main()
        {
            var numbers = new[] { 67.9, 12.1, 34.5 };

            var max = StatisticalUtils.Max(numbers);
            ConsolePrinter.PrintLine(max);

            var min = StatisticalUtils.Min(numbers);
            ConsolePrinter.PrintLine(min);

            var average = StatisticalUtils.Average(numbers);
            ConsolePrinter.PrintLine(average);
        }
    }
}
