﻿// ********************************
// <copyright file="ConsolePrinterDemo.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

/// <summary>
/// Demonstrates correct naming of identifiers in C#.
/// </summary>
internal class ConsolePrinterDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        var consolePrinter = new ConsolePrinter();
        consolePrinter.Print(true);
    }
}
