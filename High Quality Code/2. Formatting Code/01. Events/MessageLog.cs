﻿// ********************************
// <copyright file="MessageLog.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Events
{
    using System;
    using System.Text;

    /// <summary>
    /// Keeps a log of the messages which are created when
    /// adding or deleting events in an event holder.
    /// </summary>
    public class MessageLog
    {
        private readonly StringBuilder _output = new StringBuilder();

        /// <summary>
        /// Gets all the messages in the log.
        /// </summary>
        /// <value>The Output property gets the string representation of the output field.</value> 
        public string Output
        {
            get
            {
                return this._output.ToString();
            }
        }

        /// <summary>
        /// Add a message "Event added" to the message log.
        /// </summary>
        internal void EventAdded()
        {
            this._output.Append("Event added" + Environment.NewLine);
        }

        /// <summary>
        /// Add a message to the log which tells the number of deleted events
        /// or "No events found" if no events have been deleted.
        /// </summary>
        /// <param name="count">The number of deleted events.</param>
        internal void EventDeleted(int count)
        {
            if (count == 0)
            {
                this.NoEventsFound();
            }
            else
            {
                this._output.AppendFormat("{0} event(s) deleted{1}", count, Environment.NewLine);
            }
        }

        /// <summary>
        /// Adds a message to the log saying "No events found".
        /// </summary>
        public void NoEventsFound()
        {
            this._output.Append("No events found" + Environment.NewLine);
        }

        /// <summary>
        /// Adds the string representation of the <see cref="Event"/>
        /// to the message log.
        /// </summary>
        /// <param name="eventToAdd">The event which will be added in the log.</param>
        public void AddEvent(Event eventToAdd)
        {
            if (eventToAdd != null)
            {
                this._output.Append(eventToAdd + Environment.NewLine);
            }
        }
    }
}