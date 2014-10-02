// ********************************
// <copyright file="Result.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

namespace JustMinesweeper
{
    /// <summary>
    ///     Keeps the name and score of a player.
    /// </summary>
    public class Result
    {
        #region Private Fields

        /// <summary>
        ///     Represents the name of the player.
        /// </summary>
        private string _name = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        public Result()
        {
            Score = 0;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="score">The score of the player.</param>
        public Result(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the name of the player.
        /// </summary>
        /// <value>The Name property gets/sets the value of the name field.</value>
        public string Name
        {
            get { return this._name; }

            private set { this._name = value; }
        }

        /// <summary>
        ///     Gets the score of the player.
        /// </summary>
        /// <value>The Score property gets/sets the value of the score field.</value>
        public int Score { get; private set; }

        #endregion
    }
}
