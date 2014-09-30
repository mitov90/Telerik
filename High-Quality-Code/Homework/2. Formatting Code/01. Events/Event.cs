// ********************************
// <copyright file="Event.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;
using System.Text;

namespace Events
{
    /// <summary>
    ///     A class which represents an event (conference, meeting, lunch, etc.).
    /// </summary>
    public class Event : IComparable
    {
        #region Private Fields

        private const string DateAndTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private DateTime _dateAndTime;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        /// <param name="dateAndTime">The date and time of the event.</param>
        /// <param name="title">The title of the event.</param>
        /// <param name="location">The location of the event.</param>
        public Event(DateTime dateAndTime, string title, string location)
        {
            this.DateAndTime = dateAndTime;
            this.Title = title;
            this.Location = location;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets/sets the date and time of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the <see cref="System.DateTime" /> field, dateAndTime.</value>
        public DateTime DateAndTime
        {
            get { return this._dateAndTime; }

            private set { this._dateAndTime = value; }
        }

        /// <summary>
        ///     Gets/sets the title of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the title field.</value>
        public string Title { get; private set; }

        /// <summary>
        ///     Gets/sets the location of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the location field.</value>
        public string Location { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Overrides the corresponding method in <see cref="System.IComparable" />.
        ///     The events are first compared by date and time, then by title and
        ///     eventually by location.
        /// </summary>
        /// <param name="obj">The object to compare this instance with.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var other = obj as Event;
            if (other == null) throw new ArgumentException("Object is not an Event.");
            int byDateAndTime = this.DateAndTime.CompareTo(other.DateAndTime);
            int byTitle = String.Compare(this.Title, other.Title, StringComparison.Ordinal);
            int byLocation = String.Compare(this.Location, other.Location, StringComparison.Ordinal);

            if (byDateAndTime != 0) return byDateAndTime;
            return byTitle == 0 ? byLocation : byTitle;
        }

        /// <summary>
        ///     Returns event data in the following format:
        ///     {Date and Time} | {Title} [| {Location}]
        /// </summary>
        /// <returns>The event data as a string.</returns>
        public override string ToString()
        {
            var eventBuilder = new StringBuilder();

            eventBuilder.Append(this.DateAndTime.ToString(DateAndTimeFormat));

            eventBuilder.Append(" | " + this.Title);

            if (!string.IsNullOrWhiteSpace(this.Location))
            {
                eventBuilder.Append(" | " + this.Location);
            }

            return eventBuilder.ToString();
        }

        #endregion
    }
}
