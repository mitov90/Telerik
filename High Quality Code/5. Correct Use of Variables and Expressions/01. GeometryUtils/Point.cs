// ********************************
// <copyright file="Point.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace GeometryUtils
{
    /// <summary>
    /// Represents a point in the 2D Euclidean plane.
    /// </summary>
    public class Point
    {
        #region Private Fields

        /// <summary>
        /// The x-coordinate of this <see cref="GeometryUtils.Point"/>.
        /// </summary>
        private double _x;

        /// <summary>
        /// The y-coordinate of this <see cref="GeometryUtils.Point"/>.
        /// </summary>
        private double _y;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryUtils.Point"/> class.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the x-coordinate of this <see cref="GeometryUtils.Point"/>.</summary>
        /// <returns>The x-coordinate of this <see cref="GeometryUtils.Point"/>.</returns>
        public double X
        {
            get
            {
                return this._x;
            }

            set
            {
                this._x = value;
            }
        }

        /// <summary>Gets or sets the y-coordinate of this <see cref="GeometryUtils.Point"/>.</summary>
        /// <returns>The y-coordinate of this <see cref="GeometryUtils.Point"/>.</returns>
        public double Y
        {
            get
            {
                return this._y;
            }

            set
            {
                this._y = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts the coordinates of this <see cref="GeometryUtils.Point"/>.
        /// to their string representation. 
        /// </summary>
        /// <returns>A string which contains the coordinates
        /// of this <see cref="GeometryUtils.Point"/>.</returns>
        public override string ToString()
        {
            return string.Format("({0:N4}, {1:N4})", this._x, this._y);
        }

        #endregion
    }
}
