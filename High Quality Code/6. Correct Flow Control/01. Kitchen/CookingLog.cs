// ********************************
// <copyright file="CookingLog.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;
using System.Text;

namespace Kitchen
{
    /// <summary>
    ///     Keeps the actions performed by a chef while preparing the meal.
    /// </summary>
    public class CookingLog
    {
        /// <summary>
        ///     A <see cref="System.Text.StringBuilder" /> which keeps
        ///     the steps performed while cooking.
        /// </summary>
        private readonly StringBuilder _log = new StringBuilder();

        /// <summary>
        ///     Adds <paramref name="note" /> in the cooking log.
        /// </summary>
        /// <param name="note">The note to add in the log.</param>
        public void Add(string note)
        {
            var item = string.Format("{0:yyyy-MM-dd HH:mm:ss}: {1}", DateTime.Now, note);
            _log.AppendLine(item);
        }

        /// <summary>
        ///     Returns the log data.
        /// </summary>
        /// <returns>The string representation of the log.</returns>
        public override string ToString()
        {
            return _log.ToString();
        }
    }
}
