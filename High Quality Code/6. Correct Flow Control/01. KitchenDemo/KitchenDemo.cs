// ********************************
// <copyright file="KitchenDemo.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Kitchen;

/// <summary>
/// A class which demonstrates food preparation.
/// </summary>
internal class KitchenDemo
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    private static void Main()
    {
        var theDev = new Chef();
        theDev.MakeSoup();

        Console.WriteLine(theDev.Log);
    }
}
